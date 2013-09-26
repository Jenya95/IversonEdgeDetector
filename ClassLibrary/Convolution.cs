using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    public class Convolution
    {
        //Входное изображение
        static double[] img;
        //Ядра для свертки с изображением
        static Kernel[] kerns;
        //Массив с последовательностью операторов
        static cxop[] op;
        //Временный массив для вычисления значений яркостей пикселей каждой строки изображения
        static double[][] s1;
        //метод свертки изображения с заданным комплексным ядром
        public static void CxConvolve(ImageDouble input, double degree, CxKernel kern, ImageDouble out1, ImageDouble out2)
        {
            //временный массив для вычисления значений "дополнений" яркостей пикселей каждой строки изображения
            double[][] s2;
            //массивы с результирующими значениями пикселей
            double[] res1, res2;
            //считывание входных данных
            img = input.Data;
            int w = input.Width, h = input.Height, len = w * h;
            //счетчик строк
            int line = 0;

            kerns = kern.Kerns;
            op = kern.Ops;

            //инициализация временных переменных
            s1 = new double[7][];
            s2 = out2 != null ? new double[7][] : null;
            res1 = out1.Data;
            res2 = out2 != null ? out2.Data : null;

            //индексы для временных массивов и массива операторов
            int s_ind, index;
            //цикл по строкам матрицы изображения
            for (int i = 0; i < len; i += w, line++)
            {
                //цикл по последовательности операторов составляющих комплексное ядро
                for (index = 0, s_ind = 0; index < op.Length; index++, s_ind++)
                {
                    //выбор текущей операции
                    switch (op[index].Id)
                    {
                        case id.CXconvolve:
                            {
                                //свертка с ядром заданного индекса
                                int kern_idx = op[index].Iarg;
                                //инициализация и копирование временных массивов
                                if (s1[s_ind] == null) s1[s_ind] = new double[w];
                                if (s2 != null && s2[s_ind] == null) s2[s_ind] = s1[s_ind];
                                //выполнение метода свертки
                                СonvLine(i, w, h, line, kern_idx, s_ind);
                                //копирование временных массивов
                                if (s2 != null && s2[s_ind] != s1[s_ind])
                                    Array.Copy(s1[s_ind], s2[s_ind], w);
                            }
                            break;
                        case id.CXand:
                            {
                                //Объединить n элементов логическим И
                                int n = op[index].Iarg;
                                s_ind -= n;
                                //копирование временных массивов
                                if (s2 != null)
                                {
                                    if (s2[s_ind] == s1[s_ind])
                                    {
                                        s2[s_ind] = new double[w];
                                        Array.Copy(s1[s_ind], s2[s_ind], w);
                                    }
                                }
                                //выбор количества элементов
                                switch (n)
                                {
                                    case 2:
                                        {
                                            //Объединение 2 элементов
                                            double[] l0, l1;
                                            l0 = s1[s_ind]; l1 = s1[s_ind + 1];
                                            for (int k = 0; k < w; k++)
                                                l0[k] = Logics.ContinAnd2(degree, l0[k], l1[k]);
                                            //Для массива "дополнений" используется "ИЛИ"
                                            if (s2 != null)
                                            {
                                                l0 = s2[s_ind]; l1 = s2[s_ind + 1];
                                                for (int k = 0; k < w; k++)
                                                    l0[k] = Logics.ContinOr2(degree, l0[k], l1[k]);
                                            }
                                        }
                                        break;
                                    case 4:
                                        {
                                            //Объединение 4 элементов
                                            double[] l0, l1, l2, l3;
                                            l0 = s1[s_ind]; l1 = s1[s_ind + 1];
                                            l2 = s1[s_ind + 2]; l3 = s1[s_ind + 3];
                                            for (int k = 0; k < w; k++)
                                                l0[k] = Logics.ContinAnd4(degree, l0[k], l1[k], l2[k], l3[k]);
                                            //Для массива "дополнений" используется "ИЛИ"
                                            if (s2 != null)
                                            {
                                                l0 = s2[s_ind]; l1 = s2[s_ind + 1];
                                                l2 = s2[s_ind + 2]; l3 = s2[s_ind + 3];
                                                for (int k = 0; k < w; k++)
                                                    l0[k] = Logics.ContinOr4(degree, l0[k], l1[k], l2[k], l3[k]);
                                            }
                                        }
                                        break;
                                    case 5:
                                        {
                                            //Объединение 5 элементов
                                            double[] l0, l1, l2, l3, l4;
                                            l0 = s1[s_ind]; l1 = s1[s_ind + 1];
                                            l2 = s1[s_ind + 2]; l3 = s1[s_ind + 3];
                                            l4 = s1[s_ind + 4];
                                            for (int k = 0; k < w; k++)
                                                l0[k] = Logics.ContinAnd5(degree, l0[k], l1[k], l2[k], l3[k], l4[k]);
                                            //Для массива "дополнений" используется "ИЛИ"
                                            if (s2 != null)
                                            {
                                                l0 = s2[s_ind]; l1 = s2[s_ind + 1];
                                                l2 = s2[s_ind + 2]; l3 = s2[s_ind + 3];
                                                l4 = s2[s_ind + 4];
                                                for (int k = 0; k < w; k++)
                                                    l0[k] = Logics.ContinOr5(degree, l0[k], l1[k], l2[k], l3[k], l4[k]);
                                            }
                                        }
                                        break;
                                }
                            }
                            break;
                        case id.CXor:
                            {
                                //Объединение 2 элементов логическим ИЛИ
                                s_ind -= 2;                                
                                double[] l0, l1;
                                l0 = s1[s_ind]; l1 = s1[s_ind + 1];
                                for (int k = 0; k < w; k++)
                                    l0[k] = Logics.ContinOr2(degree, l0[k], l1[k]);
                                //Для массива "дополнений" используется "И"
                                if (s2 != null)
                                {
                                    l0 = s2[s_ind]; l1 = s2[s_ind + 1];
                                    for (int k = 0; k < w; k++)
                                        l0[k] = Logics.ContinAnd2(degree, l0[k], l1[k]);
                                }
                            }
                            break;
                    }
                }
                s_ind--;
                //копирование строки в результирующий массив
                Array.Copy(s1[s_ind], 0, res1, w * line, w);
                //копирование результирующих "дополнений" с противоположным знаком
                if (s2 != null)
                {
                    for (int k = 0; k < w; k++)
                        res2[w * line + k] = -s2[s_ind][k];
                }
            }
        }
        //метод свертки строки изображения с данным ядром
        static void СonvLine(int input, int w, int h, int line, int kern, int output)
        {
            //Считывание исходных данных
            int kw = kerns[kern].Width, kh = kerns[kern].Height;
            int kx = kerns[kern].Origin_x, ky = kerns[kern].Origin_y;
            double[] kdata = kerns[kern].Data;
            int image_index = input - kx - ky * w;
            int out_index = 0;
            int kp_index = 0;
            int klen;

            //Корректирование высоты ядра возле границ сверху и снизу
            //корректирование индексов ядра и изображения
            {
                int adj_top = ky - line;
                int adj_bot = kh - ky - (h - line);
                if (adj_top > 0)
                {
                    kp_index += adj_top * kw;
                    image_index += adj_top * w;
                    kh -= adj_top;
                }
                if (adj_bot > 0) { kh -= adj_bot; }
            }
            klen = kh * kw;
            //Цикл по левой границе(полю) строки изображения
            for (; out_index < kx; out_index++, image_index++)
            {
                //результирующее значение свертки с данным ядром
                //для конкретного пикселя
                double sum = 0;
                //обновление индексов
                int kp_index1 = kp_index;
                int image_index1 = image_index;
                int kw1 = kw;
                //Корректирование ширини ядра возле границ справа и слева
                //корректирование индексов ядра и изображения
                {
                    int adj_l = kx - out_index;
                    int adj_r = kw - kx - (w - out_index);

                    if (adj_l > 0)
                    {
                        kp_index1 += adj_l;
                        image_index1 += adj_l;
                        kw1 -= adj_l;
                    }
                    if (adj_r > 0) { kw1 -= adj_r; }
                }
                //Если ширина ядра после коррекции положительна
                //выполняется цикл свертки с данным ядром
                //для конкретного пикселя с индексом out_index
                if (kw1 > 0)
                {
                    for (int x = 0; x < klen; image_index1 += w, kp_index1 += kw, x += kw)
                    {
                        //обновление индексов
                        int kp_index2 = kp_index1;
                        int image_index2 = image_index1;
                        for (int y = 0; y < kw1; kp_index2++, image_index2++, y++)
                            sum += kdata[kp_index2] * img[image_index2];
                    }
                }
                //запись результата свертки для пикселя out_index 
                s1[output][out_index] = sum;
            }
            //Цикл по центру строки изображения
            {
                //Корректировка ширины, обрезка поля(границы) справа
                int adj_r = (kw - kx - 1 >= 0 ? kw - kx - 1 : 0);
                for (; out_index < w - adj_r; out_index++, image_index++)
                {
                    //результирующее значение свертки с данным ядром
                    //для конкретного пикселя
                    double sum = 0;
                    //обновление индексов
                    int kp_index1 = kp_index;
                    int image_index1 = image_index;
                    //цикл свертки с данным ядром
                    //для конкретного пикселя с индексом out_index
                    for (int y = 0; y < klen; image_index1 += w, kp_index1 += kw, y += kw)
                    {
                        //обновление индексов
                        int kp_index2 = kp_index1;
                        int image_index2 = image_index1;
                        for (int z = 0; z < kw; kp_index2++, image_index2++, z++)
                            sum += kdata[kp_index2] * img[image_index2];
                    }
                    //запись результата свертки для пикселя out_index 
                    s1[output][out_index] = sum;
                }
            }
            //Цикл по правой границе(полю) строки изображения
            for (; out_index < w; out_index++, image_index++)
            {
                //результирующее значение свертки с данным ядром
                //для конкретного пикселя
                double sum = 0;
                //обновление индексов
                int kp_index1 = kp_index;
                int image_index1 = image_index;
                int kw1 = kw;

                //Корректирование ширини ядра возле границ справа и слева
                //корректирование индексов ядра и изображения
                {
                    int adj_l = kx - out_index;
                    int adj_r = kw - kx - (w - out_index);

                    if (adj_l > 0) { kp_index1 += adj_l; image_index1 += adj_l; kw1 -= adj_l; }
                    if (adj_r > 0) { kw1 -= adj_r; }
                }
                //Если ширина ядра после коррекции положительна
                //выполняется цикл свертки с данным ядром
                //для конкретного пикселя с индексом out_index
                if (kw1 > 0)
                    for (int y = 0; y < klen; kp_index1 += kw, image_index1 += w, y += kw)
                    {
                        //обновление индексов
                        int kp_index2 = kp_index1;
                        int image_index2 = image_index1;
                        for (int z = 0; z < kw1; kp_index2++, image_index2++, z++)
                            sum += kdata[kp_index2] * img[image_index2];
                    }
                //запись результата свертки для пикселя out_index 
                s1[output][out_index] = sum;
            }
        }
    }
}