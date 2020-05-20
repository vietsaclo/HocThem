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
    public partial class FrmLamLai : Form
    {
        private bool laNguoiChoiA = true;
        private int[,] banCo;

        public FrmLamLai()
        {
            InitializeComponent();
        }

        private void FrmLamLai_Load(object sender, EventArgs e)
        {
            banCo = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = createButton(i, j);
                    banCo[i, j] = -1;
                    this.Controls.Add(btn);
                }
            }
        }

        private Button createButton(int i, int j)
        {
            Button btn = new Button();
            btn.Width = btn.Height = 50;
            btn.Location = new Point(j * 50, i* 50);
            btn.Click += btn_Click;
            btn.Tag = new Point(i, j);
            return btn;
        }

        void btn_Click(object beSen, EventArgs e)
        {
            Button btn = (Button)beSen;
            if (btn.Text != string.Empty)
                return;

            Point toaDo = (Point)btn.Tag;

            if (laNguoiChoiA)
            {
                btn.Text = "Cet";
                btn.Font = new Font(btn.Font.FontFamily, 10f);
                btn.ForeColor = Color.Red;
                banCo[toaDo.X, toaDo.Y] = 1;
            }
            else
            {
                btn.Text = "Loz";
                btn.Font = new Font(btn.Font.FontFamily, 10f);
                btn.ForeColor = Color.Blue;
                banCo[toaDo.X, toaDo.Y] = 0;
            }

            //Xet xem co thang game khong.
            if (laThangGame(banCo, toaDo))
            {
                MessageBox.Show("Game Over!");
                return;
            }

            laNguoiChoiA = !laNguoiChoiA;
        }

        private bool laThangGame(int[,] banCo, Point toaDo)
        {
            return xetTheoHangDoc(banCo, toaDo)
                || xetTheoHangNgang(banCo, toaDo)
                || xetTheoCheoChinh(banCo, toaDo)
                || xetTheoCheoPhu(banCo, toaDo);
        }

        private bool xetTheoHangDoc(int[,] banCo, Point toaDo)
        {
            //Tim start index;
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (x >= 1 && banCo[x - 1, y] == nguoiChoiHienTai)
                x -= 1;

            //Dem
            int dem = 1;
            while (x <= 8 && banCo[x + 1, y] == nguoiChoiHienTai)
            {
                x += 1;
                dem += 1;
            }

            if (dem == 5)
                return true;

            return false;
        }

        private bool xetTheoHangNgang(int[,] banCo, Point toaDo)
        {
            //Tim start index;
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (y>=1  && banCo[x, y-1] == nguoiChoiHienTai)
                y -= 1;

            //Dem
            int dem = 1;
            while (y <= 8 && banCo[x, y+1] == nguoiChoiHienTai)
            {
                y+= 1;
                dem += 1;
            }

            if (dem == 5)
                return true;

            return false;
        }

        private bool xetTheoCheoChinh(int[,] banCo, Point toaDo)
        {
            //tim start index.
            int x = toaDo.X, y = toaDo.Y;
            int nguoiChoiHienTai = banCo[x, y];
            while (y >= 1 && banCo[x - 1, y - 1] == nguoiChoiHienTai)
            {
                x -= 1;
                y -= 1;
            }
            //Dem
            int dem = 1;
            while (y <= 8 && banCo[x+1, y+1 ] == nguoiChoiHienTai)
            {
                y += 1;
                x += 1;
                dem += 1;
            }

            if (dem == 5)
                return true;
            return false;
        }

        private bool xetTheoCheoPhu(int[,] banCo, Point toaDo)
        {
            return false;
        }
    }
}