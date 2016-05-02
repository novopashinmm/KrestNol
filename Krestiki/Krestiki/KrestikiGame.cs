using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Krestiki.Properties;

namespace Krestiki
{
    public partial class KrestikiGame : Form
    {
        private bool _twoPlayers;

        private List<PictureBox> _list;

        private int _i;
        public KrestikiGame()
        {
            InitializeComponent();
            _list = new List<PictureBox>();
        }

        public List<PictureBox> FindElements()
        {
            return (from object control in Controls where control.GetType().ToString().Contains("PictureBox") where ((PictureBox)control).Name.Contains("El") select control as PictureBox).ToList();
        }

        public void Pole_MouseClick(object sender, MouseEventArgs e)
        {
            // Рисуем X или O
            CreateXorO(sender, e, Bitmap);

            // Все нарисованные X или O вносим в список
            _list = FindElements();

            if (CheckFinish(sender, e))
                return;

            _i++;

            if (!_twoPlayers)
                ComputerHod();
        }

        /// <summary>
        /// Определяем что будем рисовать X или O
        /// </summary>
        private Bitmap Bitmap
        {
            get
            {
                var bitmap = _i%2 == 0 ? Resources.Krest : Resources.Nolik;
                return bitmap;
            }
        }

        /// <summary>
        /// Проверка на выигрыш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool CheckFinish(object sender, MouseEventArgs e)
        {
            // Флаг нужный для выхода из внешнего цикла
            bool flagBreak = false;

            // В одной итерации проверяются крестики на выигрыш в другом нолики
            for (int n = 0; n < 2; n++)
            {
                var elKorN = n == 0 ? "K" : "N";
                foreach (var p1 in _list.Where(p1 => p1.Name.Contains(elKorN)))
                {
                    foreach (var p2 in _list.Where(p2 => p2.Name.Contains(elKorN)))
                    {
                        foreach (var p3 in _list.Where(p3 => p3.Name.Contains(elKorN)))
                        {
                            int p1X = p1.Location.X/80;
                            int p2X = p2.Location.X/80;
                            int p3X = p3.Location.X/80;
                            int p1Y = p1.Location.Y/80;
                            int p2Y = p2.Location.Y/80;
                            int p3Y = p3.Location.Y/80;
                            // Условие победы если подряд и они находятся на разных горизонталях
                            // x o o
                            // x o o
                            // x o o
                            if (p1X == p2X && p2X == p3X && p1Y != p2Y && p1Y != p2Y && p2Y != p3Y && p1 != p2 &&
                                p1 != p3 && p2 != p3)
                            {
                                CreateFinishLines(p1, p2, p3, "V");
                                EndGame(sender, e, elKorN);
                                return true;
                                flagBreak = true;
                                break;
                            }
                            // Условие победы если подряд 3 элемента и они находятся на разных вертикалях
                            // x x x
                            // o o o
                            // o o o
                            if (p1Y == p2Y && p2Y == p3Y && p1X != p2X && p1X != p2X && p2X != p3X && p1 != p2 &&
                                p1 != p3 && p2 != p3)
                            {
                                CreateFinishLines(p1, p2, p3, "G");
                                EndGame(sender, e, elKorN);
                                return true;
                                flagBreak = true;
                                break;
                            }

                            // Условие победы если подряд 3 диагональных элемента
                            // o o x
                            // o x o
                            // x o o
                            var pWithMinX = p1.Location.X < p2.Location.X && p1.Location.X < p3.Location.X
                                ? p1.Location
                                : p2.Location.X < p3.Location.X ? p2.Location : p3.Location;
                            var pWithMaxX = p1.Location.X > p2.Location.X && p1.Location.X > p3.Location.X
                                ? p1.Location
                                : p2.Location.X > p3.Location.X ? p2.Location : p3.Location;
                            if (p1X != p2X && p1Y != p2Y && p1X != p3X && p1Y != p3Y && p2X != p3X && p2Y != p3Y &&
                                pWithMinX.Y/80 != 1 && pWithMaxX.Y/80 != 1)
                            {
                                CreateFinishLines(p1, p2, p3, "D");
                                EndGame(sender, e, elKorN);
                                return true;
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
            return false;
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
        /// <param name="finishLine">Тип линии</param>
        private void CreateFinishLines(PictureBox p1, PictureBox p2, PictureBox p3, string finishLine)
        {
            Point pWithMinX = new Point();
            if (finishLine == "D")
                pWithMinX = p1.Location.X < p2.Location.X && p1.Location.X < p3.Location.X ? p1.Location : p2.Location.X < p3.Location.X ? p2.Location : p3.Location;

            for (int j = 0; j < 3; j++)
            {
                PictureBox picFinish = new PictureBox
                {
                    Name = "F" + j,
                    Width = 80,
                    Height = 80,
                    BackgroundImage = finishLine == "V" ? Resources.VertLine : finishLine == "G" ? Resources.GorLine : pWithMinX.Y / 80 == 0 ? Resources.Diag1 : Resources.Diag2,
                };
                if (j == 0)
                    picFinish.Location = p1.Location;
                if (j == 1)
                    picFinish.Location = p2.Location;
                if (j == 2)
                    picFinish.Location = p3.Location;
                Controls.Add(picFinish);
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
                Name = "El" + _i + (_i%2 == 0 ? "K" : "N"),
                Width = 80,
                Height = 80,
                BackgroundImage = bitmap,
                Location = point
            };
            Controls.Add(pic);
            pic.Show();
            pic.BringToFront();
        }

        /// <summary>
        /// Метод удаления контролов элементов и линий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PictureBox> allControlsForRemove = new List<PictureBox>();
            allControlsForRemove.AddRange(_list);
            allControlsForRemove.AddRange(FindLineControl());
            foreach (var control in allControlsForRemove)
            {
                Controls.Remove(control);
            }
            _i = 0;
        }

        /// <summary>
        /// Метод поиска контролов с линиями
        /// </summary>
        /// <returns></returns>
        private List<PictureBox> FindLineControl()
        {
            var listLines = (from object control in Controls where control.GetType().ToString().Contains("PictureBox") where ((PictureBox)control).Name.Contains("F") select control as PictureBox).ToList();
            return listLines;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KrestikiGame_Load(object sender, EventArgs e)
        {
            ComputerHod();
        }

        private void ComputerHod()
        {
            Random rand = new Random();
            int rX = rand.Next(40, 200);
            int rY = rand.Next(40, 200);
            List<PictureBox> list = FindElements();
            bool rNext = list.Count == 0;
            while (!rNext)
            {
                rNext = !list.Any(x => x.Location.X/80 == rX/80 && x.Location.Y/80 == rY/80);
                if (!rNext)
                {
                    rX = rand.Next(0, 240);
                    rY = rand.Next(0, 240);
                }
            }

            object sender = this.Pole;
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, rX, rY, 0);

            // Рисуем X или O
            CreateXorO(sender, e, Bitmap);;

            // Все нарисованные X или O вносим в список
            _list = FindElements();

            if (CheckFinish(sender, e))
                return;

            _i++;
        }

        private void игрокаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _twoPlayers = true;
        }

        private void противКомпьютераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _twoPlayers = false;
        }
    }
}
