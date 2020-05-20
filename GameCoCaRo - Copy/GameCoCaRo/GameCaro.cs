using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoCaRo
{
    public partial class GameCaro : Form
    {
        //Variables
        private int soO;
        private int[,] banCo;
        private bool isNguoiChoiA;
        private Stack<Point> stack;
        private Timer timer;

        public GameCaro()
        {
            InitializeComponent();
            initMyComponent();
        }

        private void initMyComponent()
        {
            soO = 10;
            banCo = new int[soO, soO];
            isNguoiChoiA = true;
            stack = new Stack<Point>();
            timer = new Timer();
        }

        private void taiGiaoDien()
        {
            pnBanCo.Controls.Clear();
            Button btn;
            for (int i = 0; i < soO; i++)
            {
                for (int j = 0; j < soO; j++)
                {
                    btn = createButton(i, j);
                    banCo[i, j] = -1;
                    pnBanCo.Controls.Add(btn);
                }
            }
        }

        private Button createButton(int i, int j)
        {
            Button btn = new Button();
            btn.Tag = new Point(i, j);
            btn.Width = btn.Height = 50;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font(btn.Font.FontFamily, 20f);
            btn.Location = new Point(j * (btn.Width + 3), i * (btn.Height + 3));
            btn.Click += btn_Click;
            return btn;
        }

        //private Point getPosition(Button btn)
        //{
        //    string[] M = btn.Tag.ToString().Split(',');
        //    return new Point(int.Parse(M[0]), int.Parse(M[1]));
        //}

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Point toaDo = (Point)btn.Tag;

            //Kiem tra co cho click ko
            if (btn.Cursor == Cursors.No)
                return;
            
            //cap nhat tren ma tran.
            if (isNguoiChoiA)
            {
                btn.Text = "X";
                btn.ForeColor = Color.Red;
                banCo[toaDo.X, toaDo.Y] = 1;
            }
            else
            {
                btn.Text = "O";
                btn.ForeColor = Color.Blue;
                banCo[toaDo.X, toaDo.Y] = 0;
            }
            btn.Cursor = Cursors.No;
            btn.Click += null;

            //kiem tra co thang ko
            if (laThangGame(banCo, toaDo))
            {
                showNguoiChoiThang(false);
                while (stack.Count != 0)
                {
                    Control ctr = timControl(stack.Pop());
                    if (ctr != null)
                        ctr.BackColor = Color.LightGray;
                }
                //Set tat ca button ko click duoc
                setButtonNonClick();
                timer.Stop();
                return;
            }

            //khong thang
            isNguoiChoiA = !isNguoiChoiA;
            setNguoiChoi();
        }

        private Control timControl(Point toaDo)
        {
            foreach (Control ctr in pnBanCo.Controls)
                if ((Point)ctr.Tag == toaDo)
                    return ctr;
            return null;
        }

        private void showNguoiChoiThang(bool hetGio)
        {
            if (hetGio)
            {
                if (isNguoiChoiA)
                    MessageBox.Show("Nguoi Choi B Thang!", "thong Bao");
                else
                    MessageBox.Show("Nguoi Choi A Thang!", "Thong Bao");
            }
            else
            {
                if (isNguoiChoiA)
                    MessageBox.Show("Nguoi Choi A Thang!", "thong Bao");
                else
                    MessageBox.Show("Nguoi Choi B Thang!", "Thong Bao");
            }
        }

        /// <summary>
        /// Hàm kiểm tra tất cả các trường hợp dọc, ngang, chéo, phụ.
        /// xem có thắng không.
        /// </summary>
        /// <param name="banCo">Lưu các số (-1, 0, 1) Tương ứng với
        /// (Chưa đánh, đánh O, đánh X)</param>
        /// <param name="toaDo">Khi một sự kiện đánh cờ liền kiểm tra xem,
        /// có thắng game hay là không.</param>
        /// <returns></returns>
        private bool laThangGame(int[,] banCo, Point toaDo)
        {
            return laThangTheoChieuDoc(banCo, toaDo) || laThangTheoChieuNgang(banCo, toaDo) || laThangTheoCheoChinh(banCo, toaDo) || laThangTheoCheoPhu(banCo, toaDo);
        }

        //kiem tra thang theo chieu doc
        private bool laThangTheoChieuDoc(int[,] banCo, Point toaDo)
        {
            stack.Clear();
            //find index;
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (x >= 1 && banCo[x - 1, y] == nguoiChoiHienTai)
                x -= 1;

            stack.Push(new Point(x, y));

            //dem
            int dem = 1;
            while (x < soO - 1 && banCo[x + 1, y] == nguoiChoiHienTai)
            {
                dem += 1;
                x += 1;
                stack.Push(new Point(x, y));
            }

            if (dem >= 5)
            {
                Point[] arr = stack.ToArray();
                Point btnCuoi = arr[0], btnDau = arr[arr.Length - 1];

                int count = 0;//Dem xem co bi chan 2 dau khong
                int btnCheck;
                if (btnDau.X >= 1)
                {
                    btnCheck = banCo[btnDau.X - 1, btnDau.Y];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                if (btnCuoi.X < soO - 1)
                {
                    btnCheck = banCo[btnCuoi.X + 1, btnCuoi.Y];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                return count < 2;
            }

            return false;
        }

        //kiem tra thang theo chieu Ngang
        private bool laThangTheoChieuNgang(int[,] banCo, Point toaDo)
        {
            stack.Clear();
            //find index;
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (y >= 1 && banCo[x, y - 1] == nguoiChoiHienTai)
                y -= 1;

            stack.Push(new Point(x, y));

            //dem
            int dem = 1;
            while (y < soO - 1 && banCo[x, y + 1] == nguoiChoiHienTai)
            {
                dem += 1;
                y += 1;
                stack.Push(new Point(x, y));
            }

            if (dem >= 5)
            {
                Point[] arr = stack.ToArray();
                Point btnCuoi = arr[0], btnDau = arr[arr.Length - 1];

                int count = 0;//Dem xem co bi chan 2 dau khong
                int btnCheck;
                if (btnDau.Y >= 1)
                {
                    btnCheck = banCo[btnDau.X, btnDau.Y - 1];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                if (btnCuoi.Y < soO - 1)
                {
                    btnCheck = banCo[btnCuoi.X, btnCuoi.Y + 1];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                return count < 2;
            }

            return false;
        }

        //kiem tra thang game theo cheo chinh
        private bool laThangTheoCheoChinh(int[,] banCo, Point toaDo)
        {
            stack.Clear();
            //start index;
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (x >= 1 && y >= 1 && banCo[x - 1, y - 1] == nguoiChoiHienTai)
            {
                x -= 1;
                y -= 1;
            }

            stack.Push(new Point(x, y));
            //dem
            int dem = 1;
            while (x < soO - 1 && y < soO - 1 && banCo[x + 1, y + 1] == nguoiChoiHienTai)
            {
                dem += 1;
                x += 1;
                y += 1;
                stack.Push(new Point(x, y));
            }
            if (dem >= 5)
            {
                Point[] arr = stack.ToArray();
                Point btnCuoi = arr[0], btnDau = arr[arr.Length - 1];

                int count = 0;//Dem xem co bi chan 2 dau khong
                int btnCheck;
                if (btnDau.X >= 1 && btnDau.Y >= 1)
                {
                    btnCheck = banCo[btnDau.X - 1, btnDau.Y - 1];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                if (btnCuoi.X < soO - 1 && btnCuoi.Y < soO - 1)
                {
                    btnCheck = banCo[btnCuoi.X + 1, btnCuoi.Y + 1];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                return count < 2;
            }

            return false;
        }

        //kiem tra thang game theo cheo phu
        private bool laThangTheoCheoPhu(int[,] banCo, Point toaDo)
        {
            stack.Clear();
            //start index;
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (x >= 1 && y < soO - 1 && banCo[x - 1, y + 1] == nguoiChoiHienTai)
            {
                x -= 1;
                y += 1;
            }

            stack.Push(new Point(x, y));
            //dem
            int dem = 1;
            while (x < soO - 1 && y >= 1 && banCo[x + 1, y - 1] == nguoiChoiHienTai)
            {
                dem += 1;
                x += 1;
                y -= 1;
                stack.Push(new Point(x, y));
            }
            if (dem >= 5)
            {
                Point[] arr = stack.ToArray();
                Point btnCuoi = arr[0], btnDau = arr[arr.Length - 1];

                int count = 0;//Dem xem co bi chan 2 dau khong
                int btnCheck;
                if (btnDau.X >= 1 && btnDau.Y < soO - 1)
                {
                    btnCheck = banCo[btnDau.X - 1, btnDau.Y + 1];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                if (btnCuoi.X < soO - 1 && btnCuoi.Y >= 1)
                {
                    btnCheck = banCo[btnCuoi.X + 1, btnCuoi.Y - 1];
                    if (btnCheck != nguoiChoiHienTai && btnCheck != -1)
                        count++;
                }

                return count < 2;
            }

            return false;
        }

        private void setNguoiChoiB()
        {
            tbNguoiChoiB.BackColor = Color.DarkBlue;
            tbNguoiChoiB.Font = new Font(tbNguoiChoiA.Font, FontStyle.Bold);
            tbNguoiChoiB.ForeColor = Color.White;

            tbNguoiChoiA.BackColor = Color.White;
            tbNguoiChoiA.Font = new Font(tbNguoiChoiA.Font, FontStyle.Regular);
            tbNguoiChoiA.ForeColor = Color.Black;
        }

        private void setNguoiChoi()
        {
            if (isNguoiChoiA)
                setNguoiChoiA();
            else
                setNguoiChoiB();
        }

        private void setNguoiChoiA()
        {
            tbNguoiChoiA.BackColor = Color.Brown;
            tbNguoiChoiA.Font = new Font(tbNguoiChoiA.Font, FontStyle.Bold);
            tbNguoiChoiA.ForeColor = Color.White;

            tbNguoiChoiB.BackColor = Color.White;
            tbNguoiChoiB.Font = new Font(tbNguoiChoiA.Font, FontStyle.Regular);
            tbNguoiChoiB.ForeColor = Color.Black;
        }

        private void setButtonNonClick()
        {
            foreach (Control btn in pnBanCo.Controls)
                if (btn is Button)
                {
                    btn.Cursor = Cursors.No;
                    btn.Click += null;
                }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            taiGiaoDien();
            btnBatDau.Enabled = false;
            btnChoiLai.Enabled = true;
            setNguoiChoi();
        }

        private void btnChoiLai_Click(object sender, EventArgs e)
        {
            btnChoiLai.Enabled = false;
            btnBatDau.Enabled = true;
        }
    }
}