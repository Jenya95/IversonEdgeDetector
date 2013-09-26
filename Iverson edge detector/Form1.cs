using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClassLibrary;


namespace Iverson_edge_detector
{
    public partial class Form1 : Form
    {
        //конструктор умолчания
        public Form1()
        {
            InitializeComponent();
            UnableThings();//отключение кнопок и меню
            Russian();//включение русского языка  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //значения порога и размеров картинки по умолчанию
            Threshold = 0.1;
            defW = pictureBox1.Width;
            defH = pictureBox1.Height;
        }
        int overzoom = 0, //считает сколько раз размеры картинки превышают размеры окна 
            scroll = 0; //счетчик масштаба картинки
        int defW, defH;//размеры картинки по умолчанию
        public static double Threshold { get; set; } //порог
        Bitmap source, previous;//сохраняют изображения для методов отмены изменений
        int ndirs = 8; //количество направлений от 0 до 180 градусов
        double degree = 32;//параметр для метода свертки
        string ClosingHeader, ClosingMessage;//текст всплывающего окна при закрытии формы
        string AboutHeader, AboutMessage;//текст "О программе"
        string NotAnImageHeader, NotAnImageMessage;//текст всплывающего окна при загрузке файла не являющегося изображением
        private void OpenImage() //настройка формы при открытии изображения
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = source = new Bitmap(Image.FromFile(openFileDialog.FileName));
                }
                catch
                {
                    MessageBox.Show(NotAnImageMessage,NotAnImageHeader,MessageBoxButtons.OK);
                    return;
                }

                SaveButton.Enabled = true;
                SaveMenuItem.Enabled = true;
                SaveAsMenuItem.Enabled = true;
                CloseMenuItem.Enabled = true;
                PositiveButton.Enabled = true;
                NegativeButton.Enabled = true;
                EdgeButton.Enabled = true;
                PositiveMenuItem.Enabled = true;
                NegativeMenuItem.Enabled = true;
                EdgeMenuItem.Enabled = true;
                ZoomInButton.Enabled = true;
                ZoomOutButton.Enabled = true;
                ScaleButton.Enabled = true;
                toolStripStatusLabel1.Text = pictureBox1.Image.Width + " x " + pictureBox1.Image.Height;
                panel1.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
                panel1.Focus();
            }
        }
        //изначальная настройка формы и
        //настройка формы после закрытия изображения
        private void UnableThings()
        {
            SaveButton.Enabled = false;
            SaveMenuItem.Enabled = false;
            SaveAsMenuItem.Enabled = false;
            CloseMenuItem.Enabled = false;
            UndoButton.Enabled = false;
            UndoMenuItem.Enabled = false;
            UndoAllMenuItem.Enabled = false;
            PositiveButton.Enabled = false;
            NegativeButton.Enabled = false;
            EdgeButton.Enabled = false;
            PositiveMenuItem.Enabled = false;
            NegativeMenuItem.Enabled = false;
            EdgeMenuItem.Enabled = false;
            ZoomInButton.Enabled = false;
            ZoomOutButton.Enabled = false;
            ScaleButton.Enabled = false;
            panel1.MouseWheel -= panel1_MouseWheel;
        }
        //Перевод формы на русский язык
        //и изначальная настройка некоторых эл-тов формы
        private void Russian()
        {
            FileMenu.Text = "Файл";
            EditMenu.Text = "Правка";
            FunctionsMenu.Text = "Функции";
            SettingsMenu.Text = "Настройки";
            OpenButton.Text = "Открыть";
            OpenMenuItem.Text = "Открыть";
            SaveButton.Text = "Сохранить как";
            SaveMenuItem.Text = "Сохранить";
            SaveAsMenuItem.Text = "Сохранить как";
            CloseMenuItem.Text = "Закрыть файл";
            ExitMenuItem.Text = "Выход";
            UndoButton.Text = "Отменить";
            UndoMenuItem.Text = "Отменить";
            UndoAllMenuItem.Text = "Отменить все изменения";
            PositiveButton.Text = "Найти светлые линии";
            NegativeButton.Text = "Найти темные линии";
            EdgeButton.Text = "Найти края";
            PositiveMenuItem.Text = "Найти светлые линии";
            NegativeMenuItem.Text = "Найти темные линии";
            EdgeMenuItem.Text = "Найти края";
            LanguageMenuItem.Text = "Язык";
            ZoomInButton.Text = "Увеличить";
            ZoomOutButton.Text = "Уменьшить";
            ScaleButton.Text = "Масштаб";
            HelpMenu.Text = "Справка";
            InstructionsMenuItem.Text = "Инструкции";
            AboutMenuItem.Text = "О программе";
            this.Text = "Детектор линий методом Iverson";
            RussianMenuItem.Checked = true;
            EnglishMenuItem.Checked = false;
            ThreshMenuItem.Text = "Установить порог";
            openFileDialog.Filter = "Файлы изображений |*.bmp;*.jpg;*.jpeg;*.tif;*.tiff;*.png;*.ico;*.gif";
            saveFileDialog.Filter = "BMP (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
            ClosingHeader = "Закрытие";
            ClosingMessage = "Сохранить изменения?";
            NotAnImageHeader = "Ошибка";
            NotAnImageMessage = "Выбранный файл не является изображением!";
            AboutHeader = "Информация";
            AboutMessage = "Национальный исследовательский университет – Высшая школа экономики\nФакультет Бизнес-информатики\nОтделение Программной инженерии\n\nКурсовая работа: Детектор линий методом Iverson\n\nВыполнил:\nСтудент группы 172ПИ Галаев Антон\n\nМосква, 2012г.";
        }
        //Перевод формы на английский язык
        private void EnglishMenuItem_Click(object sender, EventArgs e)
        {
            FileMenu.Text = "File";
            EditMenu.Text = "Edit";
            FunctionsMenu.Text = "Functions";
            SettingsMenu.Text = "Settings";
            OpenButton.Text = "Open";
            OpenMenuItem.Text = "Open";
            SaveButton.Text = "Save as";
            SaveMenuItem.Text = "Save";
            SaveAsMenuItem.Text = "Save as";
            CloseMenuItem.Text = "Close file";
            ExitMenuItem.Text = "Exit";
            UndoButton.Text = "Undo";
            UndoMenuItem.Text = "Undo";
            UndoAllMenuItem.Text = "Undo all";
            PositiveButton.Text = "Detect positive lines";
            NegativeButton.Text = "Detect negative lines";
            EdgeButton.Text = "Detect edges";
            PositiveMenuItem.Text = "Detect positive lines";
            NegativeMenuItem.Text = "Detect negative lines";
            EdgeMenuItem.Text = "Detect edges";
            LanguageMenuItem.Text = "Language";
            ThreshMenuItem.Text = "Set threshold";
            ZoomInButton.Text = "Zoom in";
            ZoomOutButton.Text = "Zoom out";
            ScaleButton.Text = "Scale";
            HelpMenu.Text = "Help";
            InstructionsMenuItem.Text = "Instructions";
            AboutMenuItem.Text = "About...";
            this.Text = "Iverson edge detector";
            openFileDialog.Filter = "Image files |*.bmp;*.jpg;*.jpeg;*.tif;*.tiff;*.png;*.ico;*.gif";
            RussianMenuItem.Checked = false;
            EnglishMenuItem.Checked = true;
            ClosingHeader = "Closing";
            ClosingMessage = "Save changes?";
            NotAnImageHeader = "Error";
            NotAnImageMessage = "This file is not an image!";
            AboutHeader = "Information";
            AboutMessage = "National Research University – Higher School of Economics\nFaculty of Business Informatics\nSchool of Software Engineering\n\nCoursework: Iverson edge detector\n\nStudent:\nGalaev Anton\n\nMoscow, 2012.";
        }
        //метод обнаружения светлых линий
        private void PositiveLineDetection()
        {
            toolstripProgressBar.Value = 0;
            previous = new Bitmap(pictureBox1.Image);
            //размеры исходного изображения
            int W = pictureBox1.Image.Width,//входное
                H = pictureBox1.Image.Height;//выходное
            //иницициализация объектов типа изображений
            ImageDouble input = new ImageDouble(W, H),
                output = new ImageDouble(W, H);
            //переменная текущего изображения
            Bitmap picture = new Bitmap(pictureBox1.Image);
            toolstripProgressBar.Value += 5;
            //Считывание яркостей пикселей исходного изображения
            //и окрашивания текущего изображения в белый цвет
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    input.Data[W * y + x] = picture.GetPixel(x, y).GetBrightness();
                    picture.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            toolstripProgressBar.Value += 15;
            //цикл по количеству направлений свертки
            for (int i = 0; i < ndirs; i++)
            {
                //создание комплексного ядра для свертки
                CxKernel line = Kernels.MakeLineCxkern(i * Math.PI / ndirs);
                //выполнение метода свертки
                //последний аргумент - изображение-"дополнение" для светлых линий не требуется
                Convolution.CxConvolve(input, degree, line, output, null);
                //цикл по полученному изображению
                for (int y = 0; y < H; y++)
                    for (int x = 0; x < W; x++)
                    {
                        //если значение яркости пикселя больше порога
                        if (output.Data[W * y + x] > Threshold)
                        {
                            //то этот пиксель окрашивается черным
                            picture.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
                toolstripProgressBar.Value += 10;
            }
            //настройка элементов формы
            pictureBox1.Image = picture;
            UndoButton.Enabled = true;
            UndoMenuItem.Enabled = true;
            UndoAllMenuItem.Enabled = true;
        }
        //метод обнаружения темных линий
        private void NegativeLineDetection()
        {
            toolstripProgressBar.Value = 0;
            previous = new Bitmap(pictureBox1.Image);
            //размеры исходного изображения
            int W = pictureBox1.Image.Width,
                H = pictureBox1.Image.Height;
            //иницициализация объектов типа изображений
            ImageDouble input = new ImageDouble(W, H),//входное
                output = new ImageDouble(W, H),//выходное
                outputn = new ImageDouble(W, H);//дополнение
            //переменная текущего изображения
            Bitmap picture = new Bitmap(pictureBox1.Image);
            toolstripProgressBar.Value += 5;
            //Считывание яркостей пикселей исходного изображения
            //и окрашивания текущего изображения в белый цвет
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    input.Data[W * y + x] = picture.GetPixel(x, y).GetBrightness();
                    picture.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            toolstripProgressBar.Value += 15;
            //цикл по количеству направлений свертки
            for (int i = 0; i < ndirs; i++)
            {
                //создание комплексного ядра для свертки
                CxKernel line = Kernels.MakeLineCxkern(i * Math.PI / ndirs);
                //выполнение метода свертки
                Convolution.CxConvolve(input, degree, line, output, outputn);
                //цикл по полученному изображению
                for (int y = 0; y < H; y++)
                    for (int x = 0; x < W; x++)
                    {
                        //если значение яркости пикселя дополнения больше порога
                        if (outputn.Data[W * y + x] > Threshold)
                        {
                            //то этот пиксель окрашивается черным
                            picture.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
                toolstripProgressBar.Value += 10;
            }
            //настройка элементов формы
            pictureBox1.Image = picture;
            UndoButton.Enabled = true;
            UndoMenuItem.Enabled = true;
            UndoAllMenuItem.Enabled = true;
        }
        //метод обнаружения краев
        private void EdgeDetection()
        {
            toolstripProgressBar.Value = 0;
            previous = new Bitmap(pictureBox1.Image);
            //размеры исходного изображения
            int W = pictureBox1.Image.Width,
                H = pictureBox1.Image.Height;
            //иницициализация объектов типа изображений
            ImageDouble input = new ImageDouble(W, H),//входное
                output = new ImageDouble(W, H),//выходное
                outputn = new ImageDouble(W, H);//дополнение
            toolstripProgressBar.Value += 5;
            //переменная текущего изображения
            Bitmap picture = new Bitmap(pictureBox1.Image);
            //Считывание яркостей пикселей исходного изображения
            //и окрашивания текущего изображения в белый цвет
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    input.Data[W * y + x] = picture.GetPixel(x, y).GetBrightness();
                    picture.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            toolstripProgressBar.Value += 15;
            //цикл по количеству направлений свертки
            for (int i = 0; i < ndirs; i++)
            {
                //создание комплексного ядра для свертки
                CxKernel line = Kernels.MakeEdgeCxkern(i * Math.PI / ndirs);
                //выполнение метода свертки
                Convolution.CxConvolve(input, degree, line, output, outputn);
                for (int y = 0; y < H; y++)
                    for (int x = 0; x < W; x++)
                    {
                        //если значение яркости пикселя или яркости дополнения больше порога
                        if (output.Data[W * y + x] > Threshold || outputn.Data[W * y + x] > Threshold)
                        {
                            //то этот пиксель окрашивается черным
                            picture.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
                toolstripProgressBar.Value += 10;
            }
            //настройка элементов формы
            pictureBox1.Image = picture;
            UndoButton.Enabled = true;
            UndoMenuItem.Enabled = true;
            UndoAllMenuItem.Enabled = true;            
        }
        //открытие второй формы для установки значения порога
        private void ThreshMenuItem_Click(object sender, EventArgs e)
        {
            int id = RussianMenuItem.Checked ? 1 : 0;//язык формы - рус. или англ.
            Form2 T = new Form2(id);
            T.ShowDialog();
        }
        //метод для установки изображения по центру формы
        private void CenterImage()
        {
            pictureBox1.Location = new Point((panel1.Width - pictureBox1.Width) / 2, (panel1.Height - pictureBox1.Height) / 2);
        }
        //метод для корректировки размеров picturebox по размерам картинки
        private void AdjustPictureBox()
        {
            if (pictureBox1.Height < pictureBox1.Width)
                pictureBox1.Width = (int)(pictureBox1.Image.Width * pictureBox1.Height / pictureBox1.Image.Height);
            else pictureBox1.Height = (int)(pictureBox1.Image.Height * pictureBox1.Width / pictureBox1.Image.Width);
        }
        //увеличение картинки
        private void ZoomIn(double sc)
        {
            //увеличение
            pictureBox1.ClientSize = new Size((int)(sc * pictureBox1.Width), (int)(sc * pictureBox1.Height));
            scroll++; AdjustPictureBox();//корректировка
            if (panel1.Width > pictureBox1.Width && panel1.Height > pictureBox1.Height)
            {
                CenterImage(); ZoomOutButton.Enabled = true;//установка по центру
            }
            else //если превышает размеры формы
            {
                if (overzoom++ == 15 || scroll > 15) ZoomInButton.Enabled = false;//при чрезмерном увеличении
                panel1.AutoScrollPosition = new Point((pictureBox1.Width - panel1.ClientRectangle.Width) / 2,
                (pictureBox1.Height - panel1.ClientRectangle.Height) / 2);//полосы прокрутки по центру
            }
        }
        //уменьшение картинки
        private void ZoomOut(double sc)
        {
            //если уже уменьшено чрезмерно
            if (pictureBox1.Width < 50 || pictureBox1.Height < 50)
            {
                ZoomOutButton.Enabled = false;
                return;
            }
            //уменьшение
            pictureBox1.ClientSize = new Size((int)(pictureBox1.Width / sc), (int)(pictureBox1.Height / sc));
            scroll--; AdjustPictureBox();//корректировка
            if (overzoom == 0)
            {
                CenterImage();//установка по центру
            }
            else//если превышает размеры формы
            {
                overzoom--; ZoomInButton.Enabled = true;//уменьшение счетчика
                panel1.AutoScrollPosition = new Point((pictureBox1.Width - panel1.ClientRectangle.Width) / 2,
                (pictureBox1.Height - panel1.ClientRectangle.Height) / 2);//полосы прокрутки по центру
            }
        }
        //метод для меню "масштаб"
        private void ScalePic(int sc)
        {
            //масштабирование исходной картинки
            pictureBox1.ClientSize = new Size((int)(defW * sc / 100), (int)(defH * sc / 100));
            //выбор определенного масштаба и корректировка счетчиков
            switch (sc)
            {
                case 100:
                    scroll = -1;
                    break;
                case 125:
                    scroll = 0;
                    break;
                case 150:
                    scroll = 1;
                    break;
                case 200:
                    scroll = 3;
                    break;
                case 400:
                    scroll = 7;
                    break;
            }
            ZoomIn(1);//для корректировки размеров и полей
        }
        //обработчик события прокрутки колеса мыши
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && scroll < 15)
                ZoomIn(1.2); //увеличение картинки (прокрутка вперед)
            if (e.Delta < 0 && scroll > -15)
                ZoomOut(1.2); //уменьшение картинки(прокрутка назад)
        }
        //обработчик события закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UndoButton.Enabled) //если есть изменения
                //всплывающее окно: выбор ответа пользователя
                switch (MessageBox.Show(ClosingMessage, ClosingHeader, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes: //сохранить
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            pictureBox1.Image.Save(saveFileDialog.FileName);
                        break;
                    case DialogResult.No: //закрыть
                        break;
                    case DialogResult.Cancel: //отменить закрытие
                        e.Cancel = true;
                        break;
                }
        }

        //обработчика события для вызова справки к программе
        private void InstructionsMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("Help.chm"))//файл справки существует
                System.Diagnostics.Process.Start("Help.chm");
        }
        //окно "О программе"
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AboutMessage, AboutHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Далее следует описание простых обработчиков событий на кнопки и меню главной формы
        //обработчики преимущественно вызывают вышеописанные методы

        //2 обработчика для открытия изображения
        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenImage();
        }
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }
        //3 обработчика для сохранения в файл
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog.FileName);
        }
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(openFileDialog.FileName);
        }
        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog.FileName);
        }
        //закрытие изображения
        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            UnableThings();
        }
        //закрытие программы
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //3 обработчика для отмены изменений
        private void UndoButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = previous;
            UndoButton.Enabled = false;
            UndoMenuItem.Enabled = false;
        }
        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = previous;
            UndoButton.Enabled = false;
            UndoMenuItem.Enabled = false;
        }
        //отменить все изменения
        private void UndoAllMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = source;
            UndoButton.Enabled = false;
            UndoMenuItem.Enabled = false;
            UndoAllMenuItem.Enabled = false;
        }
        //методы обнаружения границ
        private void PositiveButton_Click(object sender, EventArgs e)
        {
            PositiveLineDetection();
        }
        private void NegativeButton_Click(object sender, EventArgs e)
        {
            NegativeLineDetection();
        }
        private void EdgeButton_Click(object sender, EventArgs e)
        {
            EdgeDetection();
        }
        private void PositiveMenuItem_Click(object sender, EventArgs e)
        {
            PositiveLineDetection();
        }
        private void NegativeMenuItem_Click(object sender, EventArgs e)
        {
            NegativeLineDetection();
        }
        private void EdgeMenuItem_Click(object sender, EventArgs e)
        {
            EdgeDetection();
        }
        //русский язык
        private void RussianMenuItem_Click(object sender, EventArgs e)
        {
            Russian();
        }
        //2 обработчика для центровки картинки при изменении размеров формы
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            CenterImage();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterImage();
        }
        //2 кнопки для масштабирования
        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            ZoomIn(1.2);
        }
        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            ZoomOut(1.2);
        }
        //6 разных масштабов в меню "Масштаб" в строке состояния
        private void Scale50MenuItem_Click(object sender, EventArgs e)
        {
            ScalePic(50);
        }
        private void Scale100MenuItem_Click(object sender, EventArgs e)
        {
            ScalePic(100);
        }
        private void Scale125MenuItem_Click(object sender, EventArgs e)
        {
            ScalePic(125);
        }
        private void Scale150MenuItem_Click(object sender, EventArgs e)
        {
            ScalePic(150);
        }
        private void Scale200MenuItem_Click(object sender, EventArgs e)
        {
            ScalePic(200);
        }
        private void Scale400MenuItem_Click(object sender, EventArgs e)
        {
            ScalePic(400);
        }
    }
}