using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krestiki
{
    public partial class KrestikiGame : Form
    {
        private List<PictureBox> list;

        private int i = 0;
        public KrestikiGame()
        {
            InitializeComponent();
            list = new List<PictureBox>();
        }

        private void Pole_MouseClick(object sender, MouseEventArgs e)
        {
            // Определяем что будем рисовать X или O
            Bitmap bitmap;
            bitmap = i%2 == 0 ? Krestiki.Properties.Resources.Krest : Krestiki.Properties.Resources.Nolik;

            // Рисуем X или O
            CreateXorO(sender, e, bitmap);

            // Все нарисованные X или O вносим в список
            list = (from object control in this.Controls where control.GetType().ToString().Contains("PictureBox") where ((PictureBox) control).Name.Contains("El") select control as PictureBox).ToList();

            // Флаг нужный для выхода из внешнего цикла
            bool flagBreak = false;

            // В одной итерации проверяются крестики на выигрыш в другом нолики
            for (int n = 0; n < 2; n++)
            {
                string elKorN;
                elKorN = n == 0 ? "K" : "N";
                foreach (var p1 in list.Where(p1 => p1.Name.Contains(elKorN)))
                {
                    foreach (var p2 in list.Where(p2 => p2.Name.Contains(elKorN)))
                    {
                        foreach (var p3 in list.Where(p3 => p3.Name.Contains(elKorN)))
                        {
                            int p1x = p1.Location.X/80;
                            int p2x = p2.Location.X/80;
                            int p3x = p3.Location.X/80;
                            int p1y = p1.Location.Y/80;
                            int p2y = p2.Location.Y/80;
                            int p3y = p3.Location.Y/80;
                            // Условие победы если подряд и они находятся на разных горизонталях
                            // x o o
                            // x o o
                            // x o o
                            if (p1x == p2x && p2x == p3x && p1y != p2y && p1y != p2y && p2y != p3y && p1 != p2 &&
                                p1 != p3 && p2 != p3)
                            {
                                CreateFinishLines(p1, p2, p3, "V");
                                EndGame(sender, e, elKorN);
                                flagBreak = true;
                                break;
                            }
                            // Условие победы если подряд 3 элемента и они находятся на разных вертикалях
                            // x x x
                            // o o o
                            // o o o
                            if (p1y == p2y && p2y == p3y && p1x != p2x && p1x != p2x && p2x != p3x && p1 != p2 &&
                                p1 != p3 && p2 != p3)
                            {
                                CreateFinishLines(p1, p2, p3, "G");
                                EndGame(sender, e, elKorN);
                                flagBreak = true;
                                break;
                            }

                            // Условие победы если подряд 3 диагональных элемента
                            // o o x
                            // o x o
                            // x o o
                            Point pWithMinX = new Point();
                                pWithMinX = p1.Location.X < p2.Location.X && p1.Location.X < p3.Location.X ? p1.Location : p2.Location.X < p3.Location.X ? p2.Location : p3.Location;
                            Point pWithMaxX = new Point();
                                pWithMaxX = p1.Location.X > p2.Location.X && p1.Location.X > p3.Location.X ? p1.Location : p2.Location.X > p3.Location.X ? p2.Location : p3.Location;
                                if (p1x != p2x && p1y != p2y && p1x != p3x && p1y != p3y && p2x != p3x && p2y != p3y && pWithMinX.Y / 80 != 1 && pWithMaxX.Y/80 != 1)
                            {
                                CreateFinishLines(p1, p2, p3, "D");
                                EndGame(sender, e, elKorN);
                                flagBreak = true;
                                break;
                            }
                        }
                        if (flagBreak)
                            break;
                    }
                    if (flagBreak)
                        break;
                }
            }

            i++;
        }

        public void EndGame(object sender, EventArgs args, string elKorN)
        {
            if (DialogResult.OK == MessageBox.Show(elKorN == "K" ? "Поздравляем! Победили крестики!" : "Поздравляем! Победили нолики!"))
            {
                новаяИграToolStripMenuItem_Click(sender, args);
            }
        }

        /// <summary>
        /// Рисуем финишные линии
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        private void CreateFinishLines(PictureBox p1, PictureBox p2, PictureBox p3, string FinishLine)
        {
            Point pWithMinX = new Point();
            if (FinishLine == "D")
                pWithMinX = p1.Location.X < p2.Location.X && p1.Location.X < p3.Location.X ? p1.Location : p2.Location.X < p3.Location.X ? p2.Location : p3.Location;

            for (int j = 0; j < 3; j++)
            {
                PictureBox picFinish = new PictureBox
                {
                    Name = "F" + j,
                    Width = 80,
                    Height = 80,
                    BackgroundImage = FinishLine == "V" ? Krestiki.Properties.Resources.VertLine : FinishLine == "G" ? Krestiki.Properties.Resources.GorLine : pWithMinX.Y / 80 == 0 ? Krestiki.Properties.Resources.Diag1 : Krestiki.Properties.Resources.Diag2,
                };
                if (j == 0)
                    picFinish.Location = p1.Location;
                if (j == 1)
                    picFinish.Location = p2.Location;
                if (j == 2)
                    picFinish.Location = p3.Location;
                this.Controls.Add(picFinish);
                picFinish.Show();
                picFinish.BringToFront();
            }
        }

        /// <summary>
        /// Рисуем X или O в месте где произошел клик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="bitmap"></param>
        private void CreateXorO(object sender, MouseEventArgs e, Bitmap bitmap)
        {
            int x = e.X/80;
            int y = e.Y/80;
            Point point = ((PictureBox) sender).Location;
            point.X = point.X + x*80;
            point.Y = point.Y + y*80;
            PictureBox pic = new PictureBox
            {
                Name = "El" + i + (i%2 == 0 ? "K" : "N"),
                Width = 80,
                Height = 80,
                BackgroundImage = bitmap,
                Location = point
            };
            this.Controls.Add(pic);
            pic.Show();
            pic.BringToFront();
        }

        /// <summary>
        /// Метод удаления контролов элементов и линий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void новаяИграToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            List<PictureBox> allControlsForRemove = new List<PictureBox>();
            allControlsForRemove.AddRange(list);
            allControlsForRemove.AddRange(FindLineControl());
            foreach (var control in allControlsForRemove)
            {
                this.Controls.Remove(control);
            }
        }

        /// <summary>
        /// Метод поиска контролов с линиями
        /// </summary>
        /// <returns></returns>
        private List<PictureBox> FindLineControl()
        {
            List<PictureBox> listLines = new List<PictureBox>();
            listLines = (from object control in this.Controls where control.GetType().ToString().Contains("PictureBox") where ((PictureBox)control).Name.Contains("F") select control as PictureBox).ToList();
            return listLines;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
