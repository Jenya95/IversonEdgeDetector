using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Kernels
    {
        //Константы для создания ядер
        const double sx = 2.5;//параметр сигма для функции Гаусса
        const int xn = 4;//количество частей разделенного ядра
        const double deg = 2.0;//коэффициэнт для создания разделенного оператора
        const double stab = 0.2;//коэффицициэнт стабилизации 
        const double sy = 1.4;//параметр сигма для функции Гаусса
        const double sep = 0.8;//смещение для функции Гаусса

        //метод для создания комплексного ядра для линий
        public static CxKernel MakeLineCxkern(double dir)
        {
            //создание базиса для линий
            Basis by = MakeLineBasis(sy, sep);
            //размер ядер
            int size = (int)Math.Ceiling(8 * Math.Max(sx, sy) + sep);
            //создание разделенного комплексного ядра
            CxKernel cxkern = MakeDividedCxkern(dir, size, by, sx, xn, deg, stab);
            return cxkern;
        }
        //метод для создания комплексного ядра для краев
        public static CxKernel MakeEdgeCxkern(double dir)
        {
            //создание базиса для краев
            Basis by = MakeEdgeBasis(sy, sep);
            //размер ядер
            int size = (int)Math.Ceiling(8 * Math.Max(sx, sy) + sep);
            //создание разделенного комплексного ядра
            CxKernel cxkern = MakeDividedCxkern(dir, size, by, sx, xn, deg, stab);
            return cxkern;
        }
        //создание базиса для линий
        static Basis MakeLineBasis(double sigma, double sep)
        {
            BasisComp[] comps = new BasisComp[4];
            Basis bas;
            //масштаб для ядра под макс. значение равное 1.0
            double base_scl = 2 / (Math.Sqrt(Math.PI) * sigma);
            base_scl /= 3;
            double scl = base_scl;
            //Нормировать производную по интервалу sep
            scl /= 2 * sep;
            //первые производные с 2 сторон
            comps[0] = new BasisComp(Gaussian.dG, scl, sep, new double[] { sigma });
            comps[1] = new BasisComp(Gaussian.dG, -scl, -sep, new double[] { sigma });

            // Значение масштаба равно (d3G*Step)(0)/(dG*Step)(0)
            scl = base_scl * Math.Sqrt(2) * sigma * sigma / 8;
            // Нормировать производную по интервалу sep
            scl /= 2 * sep;
            //3 производные с 2 сторон
            comps[2] = new BasisComp(Gaussian.d3G, -scl, sep, new double[] { sigma / Math.Sqrt(2) });
            comps[3] = new BasisComp(Gaussian.d3G, scl, -sep, new double[] { sigma / Math.Sqrt(2) });
            //создание базиса
            bas = new Basis(4, comps);
            return bas;
        }
        //создание базиса для краев
        static Basis MakeEdgeBasis(double sigma, double sep)
        {
            BasisComp[] comps = new BasisComp[5];
            Basis bas;
            //масштаб для ядра под макс. значение равное 1.0
            double base_scl = 2 / (Math.Sqrt(Math.PI) * sigma);
            base_scl /= 5;
            //первая производная
            comps[0] = new BasisComp(Gaussian.dG, base_scl, 0.0, new double[] { sigma });

            // Значение масштаба равно (dG*Step)(0)/(d3G*Step)(0)
            double scl = base_scl * sigma * sigma / 2;
            // Нормировать производную по интервалу sep
            scl /= 2 * sep;
            //вторые производные с 2 сторон
            comps[1] = new BasisComp(Gaussian.d2G, scl, sep, new double[] { sigma });
            comps[2] = new BasisComp(Gaussian.d2G, -scl, -sep, new double[] { sigma });

            //Значение масштаба равно (dG*Step)(0)/(d5G*Step)(0)
            scl = base_scl * Math.Sqrt(2) * sigma * sigma * sigma * sigma / 96;
            // Нормировать производную по интервалу sep
            scl /= 2 * sep;
            //четвертые производные с 2 сторон
            comps[3] = new BasisComp(Gaussian.d4G, -scl, sep, new double[] { sigma / Math.Sqrt(2) });
            comps[4] = new BasisComp(Gaussian.d4G, scl, -sep, new double[] { sigma / Math.Sqrt(2) });

            bas = new Basis(5, comps);

            return bas;
        }
        //создание разделенного комплексного ядра
        static CxKernel MakeDividedCxkern(double dir, int size, Basis by, double sx, int n, double degree, double stab)
        {
            CxKernel cxkern;
            //создание разделенного базиса
            Basis bx = MakeDividedGbasis(n, sx, degree, stab);
            //создание, нормирование и сжатие ядер
            Kernel[] kerns;
            MakeBasisKernels(size, bx, by, dir, 1.0, out kerns);
            NormalizeKernels(kerns, 1.0);
            ShrinkKernels(kerns, 127.0);
            //создание операторов
            cxop[] ops;
            MakeEndlineCxOps(bx.Ncomps, by.Ncomps, out ops);

            cxkern = new CxKernel(kerns, ops);
            return cxkern;
        }
        //создание разделенного базиса
        static Basis MakeDividedGbasis(int n, double sx, double degree, double stab)
        {
            //аргументы заложенного в базис метода
            double[] args = new double[] { n, sx, degree, stab };
            //вычисление точек разделения линейного оператора
            ComputePartitionPoints(n, degree);
            //создание конкретного разделенного базиса
            return MakeSelectedBasis(n, DividedG, 1.0, 0.0, 4, args);
        }
        //массивы для хранения значений разделения оператора
        const int max_parts = 8;
        static double[][] part_off = new double[max_parts + 1][];
        static double[] part_degree = new double[max_parts + 1];
        //вычисление точек разделения линейного оператора
        static void ComputePartitionPoints(int n, double degree)
        {
            const int w = 256;
            const double range = 8;
            double[] vals = new double[w];
            double y, sum = 0;
            int j = 0;

            //Запомнить количество частей оператора
            if (part_degree[n] == degree) return;
            part_degree[n] = degree;


            // Вычисление интеграла Гауссианы
            for (int i = 0; i < w; i++)
                vals[i] = sum += Gaussian.G(2 * range * i / w - range, 1.0);
            // Нормирование до 1.0
            for (int i = 0; i < w; ++i)
                vals[i] /= sum;

            //Приблизительное вычисление точек разделения, независимо от degree
            y = 1.0 / n;
            part_off[n] = new double[max_parts];
            for (int i = 0; i < w - 1; i++)
            {
                if (vals[i] <= y && vals[i + 1] > y)
                {
                    double y0 = vals[i] - y;
                    double y1 = vals[i + 1] - y;
                    double x0 = 2 * range * (i + 0.5) / w - range;
                    double x1 = 2 * range * (i + 1.5) / w - range;
                    part_off[n][j] = (x1 * y0 - x0 * y1) / (y0 - y1);

                    if (++j >= n) break;
                    y += 1.0 / n;
                }
            }
        }
        //создание конкретного разделенного базиса
        static Basis MakeSelectedBasis(int ncomps, DividedGauss f, double scale, double off, int nargs, double[] args)
        {
            BasisComp[] comps = new BasisComp[ncomps];
            Basis basisp;

            //заполнение компонентов базиса
            for (int i = 0; i < ncomps; ++i)
            {
                double[] temp = new double[nargs + 1];
                temp[0] = i;
                Array.Copy(args, 0, temp, 1, nargs);
                comps[i] = new BasisComp(f, scale, off, temp);
            }
            basisp = new Basis(ncomps, comps);
            return basisp;
        }
        //базисный метод заложенный в разделенный базис
        static double DividedG(double x, double r1, double n1, double sigma, double degree, double stab)
        {
            int r = (int)r1,//индекс региона оператора
                n = (int)n1;//количество регионов(разделений)
            double v;
            //массив с точками разделения
            double[] part = part_off[n];

            degree *= sigma;
            v = Gaussian.G(x, sigma);

            if (r == 0)
                //Левый регион
                v *= Logics.SmoothPartition(-(x - part[r] * sigma), degree);
            else if (r == n - 1)
                //Правый регион
                v *= Logics.SmoothPartition(x - part[r - 1] * sigma, degree);
            else
                //Внутренние регионы
                v *= Logics.SmoothPartition(-(x - part[r] * sigma), degree)
                  + Logics.SmoothPartition((x - part[r - 1] * sigma), degree) - 1.0;
            //Дополнительная стабилизация
            if (stab > 0)
            {
                if (r == n / 2 - 1)
                    v += stab * sigma * Gaussian.dG(x, sigma);
                else if (r == n / 2)
                    v -= stab * sigma * Gaussian.dG(x, sigma);
            }
            return v;
        }
        //создание и заполнение ядер
        static void MakeBasisKernels(int size, Basis bx, Basis by, double rot, double scl, out Kernel[] kernsp)
        {
            //размеры ядер
            int w = size, h = size, org_x = size / 2, org_y = size / 2;
            //количество ядер
            int nx = bx.Ncomps, ny = by.Ncomps, nkerns = nx * ny;
            Kernel[] kerns = new Kernel[nkerns];
            int k = 0;
            //перебор компонентов 2-х базисов: разделенного и линейного
            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++, k++)
                {
                    //создание и заполнение каждого ядра
                    kerns[k] = new Kernel(w, h, org_x, org_y, new double[w * h]);
                    FillKernel(kerns[k], bx, i, by, j, rot, scl);
                }
            }
            kernsp = kerns;
        }
        //заполнение определенного ядра значениями
        static void FillKernel(Kernel kern, Basis bx, int i, Basis by, int j, double rot, double scl)
        {
            //параметры данного ядра
            int kw = kern.Width, kh = kern.Height, klen = kw * kh;
            int org_x = kern.Origin_x, org_y = kern.Origin_y;
            double[] kp = kern.Data;
            //косинус и синус поворота
            double cr = Math.Cos(rot), sr = Math.Sin(rot);
            double y = -org_y;
            //вычисление значений ядра
            for (int m = 0; m < klen; m += kw, y++)
            {
                double x = -org_x;
                for (int n = 0; n < kw; n++, x++)
                {
                    double v = scl;
                    v *= EvalBasisComp(bx.Comps[i], cr * x + sr * y);
                    v *= EvalBasisComp(by.Comps[j], -sr * x + cr * y);
                    kp[m + n] = v;
                }
            }
        }
        //вычисление определенного значения в ядре
        static double EvalBasisComp(BasisComp comp, double x)
        {
            //значение
            double v = 0;
            //количество аргументов заложенной в базис функции
            int n = comp.Args.Length;
            //аргументы
            double[] a = comp.Args;
            //смещение
            x -= comp.Off;
            switch (n)
            {
                //case для функции производной от Гауссианы
                case 1: v = comp.f(x, a[0]); break;
                //саse для метода разделенного базиса
                case 5: v = comp.d(x, a[0], a[1], a[2], a[3], a[4]); break;
            }
            return comp.Scale * v;
        }
        //Нормирование ядер
        static void NormalizeKernels(Kernel[] kerns, double response)
        {
            //параметры ядер
            int nkerns = kerns.Length;
            int kw = kerns[0].Width, kh = kerns[0].Height, len = kw * kh;
            int org_x = kerns[0].Origin_x, org_y = kerns[0].Origin_y;
            //массив для сумм значений ядер
            double[] sum = new double[len];
            double scale;

            //сложение значений всех ядер в массив sum
            for (int i = 0; i < nkerns; i++)
            {
                if (kerns[i].Width != kw
                || kerns[i].Height != kh
                || kerns[i].Origin_x != org_x
                || kerns[i].Origin_y != org_y) throw new Exception("Cannot normalize, kernels incompatible!");

                double[] kp = kerns[i].Data;
                for (int k = 0; k < len; k++)
                    sum[k] += kp[k];
            }
            //Вычисление суммарного положительного сигнала
            double pos = 0;
            foreach (double element in sum)
            {
                double v = element;
                if (v > 0) pos += v;
            }
            scale = response / pos;

            //Нормирование всех ядер с помощью scale
            for (int i = 0; i < nkerns; i++)
            {
                double[] kp = kerns[i].Data;
                for (int j = 0; j < len; j++)
                    kp[j] *= scale;
            }
        }
        //обрезка и сжатие ядер по краям 
        static void ShrinkKernels(Kernel[] kerns, double range)
        {
            //цикл по всем ядрам
            int nkerns = kerns.Length;
            for (int n = 0; n < nkerns; n++)
            {
                //параметры данного ядра
                int kw = kerns[n].Width, kh = kerns[n].Height, klen = kw * kh;
                int org_x = kerns[n].Origin_x, org_y = kerns[n].Origin_y;
                double[] data = kerns[n].Data;
                //нахождение максимума и вычисление минимального порога
                double max = 0;
                for (int i = 0; i < klen; i++)
                {
                    double v = Math.Abs(data[i]);
                    if (v > max) max = v;
                }
                double min = max / range;

                //Далее обрезка нулевых краев ядра

                //массивы, запоминающие нулевые строки и столбцы
                bool[] row_nonzero = new bool[kh];
                bool[] col_nonzero = new bool[kw];
                //новые значения размеров ядра и смещения
                int nw = kw, nh = kh;
                int offx = 0, offy = 0;
                int row = 0;

                // Заполнение массивов, запоминающих ненулевые и нулевые значения
                for (int i = 0; i < klen; i += kw, row++)
                    for (int j = 0; j < kw; j++)
                    {
                        bool nonzero = Math.Abs(data[i + j]) > min;
                        row_nonzero[row] |= nonzero;
                        col_nonzero[j] |= nonzero;
                    }

                //Вычисление количества строк для обрезки сверху и снизу
                //и количества стобцов для обрезки по сторонам

                //Сверху
                for (int i = 0; i < kh; i++)
                {
                    if (row_nonzero[i]) break;
                    else { --nh; ++offy; }
                }
                //Снизу
                for (int i = kh - 1; i >= 0; i--)
                {
                    if (row_nonzero[i]) break;
                    else --nh;
                }
                //Слева
                for (int i = 0; i < kw; i++)
                {
                    if (col_nonzero[i]) break;
                    else { --nw; ++offx; }
                }
                //Справа
                for (int i = kw - 1; i >= 0; i--)
                {
                    if (col_nonzero[i]) break;
                    else --nw;
                }


                //Создание нового массива без нулевых строк и столбцов
                if (nw < kw || nh < kh)
                {
                    double[] newdata = new double[nh * nw];
                    int m = 0;
                    for (int i = kw * offy + offx; i < kw * (offy + nh) + offx; i += kw)
                        for (int j = 0; j < nw; j++, m++)
                            newdata[m] = Math.Abs(data[i + j]) > min ? data[i + j] : 0;

                    //Обновление параметров ядра по новым размерам
                    kw = nw; kh = nh;
                    org_x -= offx; org_y -= offy;
                    data = newdata;
                }
                //Задание обновленных свойств ядра
                kerns[n] = new Kernel(kw, kh, org_x, org_y, data);
            }
        }
        //создание операторов задающих последовательность свертки
        static void MakeEndlineCxOps(int nx, int ny, out cxop[] opsp)
        {
            //число операторов
            int nops = (ny + 1) * nx + 3;
            cxop[] ops = new cxop[nops];
            //индекс оператора
            int i = 0;
            //количество регионов справа или слева
            int n_side = nx / 2 - 1;
            int j;

            //Создание операторов для центральных регионов оператора
            ops = CombineRegion(ops, n_side, ny, ref i);
            ops = CombineRegion(ops, n_side + 1, ny, ref i);
            //Оба региона затем соединены логическим И
            ops[i].Id = id.CXand; ops[i++].Iarg = 2;
            //Создание операторов для региона слева
            for (j = 0; j < n_side; j++)
                ops = CombineRegion(ops, j, ny, ref i);
            //Создание операторов для региона справа
            for (j = n_side + 2; j < nx; j++)
                ops = CombineRegion(ops, j, ny, ref i);

            //Логическое ИЛИ для операторов левого и правого регионов
            ops[i].Id = id.CXor; ops[i++].Iarg = 2;
            //Логическое И объединяющее внутренние и внешние регионы
            ops[i].Id = id.CXand; ops[i++].Iarg = 2;

            opsp = ops;
        }
        //задание параметров операторов для определенного региона
        static cxop[] CombineRegion(cxop[] op, int r, int n, ref int i)
        {
            //индекс начала региона
            int b = n * r;
            //цикл по количеству ядер в данном регионе
            for (int k = 0; k < n; k++)
            {
                op[i].Id = id.CXconvolve;//операция свертки
                op[i++].Iarg = b + k;//индекс ядра
            }
            //следующий оператор - логическое И операторов свертки этого региона
            op[i].Id = id.CXand;
            op[i].Iarg = n;
            i++;
            return op;
        }

    }
}