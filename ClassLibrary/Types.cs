using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    //Класс, представляющий изображение
    public class ImageDouble
    {
        //ширина и высота изображения
        int width, height;
        //массив со значениями яркостей пикселей
        double[] data;
        //соотвествующие свойства
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }
        //конструктор класса
        public ImageDouble(int w, int h)
        {
            width = w;
            height = h;
            data = new double[h*w];
        }
    }
    //делегат для представления функций, производных от Гауссианы
    public delegate double Gauss(double x, double s);
    //делегат для представления метода DividedGauss
    public delegate double DividedGauss(double x, double r1, double n1, double sigma, double degree, double stab);
    //ядро (kernel) для свертки с изображением
    public class Kernel
    {
        //ширина и высота
        int width, height;
        //массив значений
        double[] data;
        //центральные значения
        int origin_x, origin_y;
        //соответствующие свойства
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }
        public int Origin_y
        {
            get { return origin_y; }
            set { origin_y = value; }
        }
        public int Origin_x
        {
            get { return origin_x; }
            set { origin_x = value; }
        }
        //конструктор
        public Kernel(int w, int h, int o_x, int o_y, double[] d)
        {
            width = w;
            height = h;
            origin_x = o_x;
            origin_y = o_y;
            data = d;
        }
    }
    //перечисление типов операторов, задающих последовательность свертки
    public enum id { CXconvolve, CXand, CXor};
    //структура задающая тип операторов и индекс оператора
    public struct cxop
    {
        //тип оператора
        id id;
        //индекс соответсвующего ядра для Convolve        
        //и кол-во используемых элементов для AND или OR 
        int iarg;
        //соответствующие свойства
        public id Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Iarg
        {
            get { return iarg; }
            set { iarg = value; }
        }       
    }
    //Комплексное ядро для свертки с изображением
    public class CxKernel
    {
        //массив с ядрами для свертки
        Kernel[] kerns;       
        //массив с операторами, задающими последовательность свертки
        cxop[] ops;
        //соответствующие свойства
        public Kernel[] Kerns
        {
            get { return kerns; }
            set { kerns = value; }
        }
        public cxop[] Ops
        {
            get { return ops; }
            set { ops = value; }
        }
        //конструктор
        public CxKernel(Kernel[] k, cxop[] o)
        {
            kerns = k;
            ops = o;
        }
    }
    //компонент базиса, заложенный в ядро
    public class BasisComp
    {
        //функция, заложенная в ядро, f или d
        public Gauss f;
        public DividedGauss d;
        //масштаб и смещение
        double scale, off;
        //аргументы функции
        double[] args;
        //соответствующие свойства
        public double Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public double Off
        {
            get { return off; }
            set { off = value; }
        }
        public double[] Args
        {
            get { return args; }
            set { args = value; }
        }
        //2 конструктора, отличающиеся вкладываемой функцией
        public BasisComp(Gauss f1, double scale1, double off1, double[] args1)
        {
            f = f1;
            d = null;
            scale = scale1;
            off = off1;
            args = args1;
        }
        public BasisComp(DividedGauss d1, double scale1, double off1, double[] args1)
        {
            d = d1;
            f = null;
            scale = scale1;
            off = off1;
            args = args1;
        }
    }
    //базис содержащий компоненты, 
    //необходимые для распознавания определенного типа границ
    public class Basis
    {
        //кол-во компонентов
        int ncomps;
        //массив с компонентами
        BasisComp[] comps;
        //соответствующие свойства
        public int Ncomps
        {
            get { return ncomps; }
            set { ncomps = value; }
        }
        public BasisComp[] Comps
        {
            get { return comps; }
            set { comps = value; }
        }
        //конструктор
        public Basis(int ncomps1, BasisComp[] comps1)
        {
            ncomps = ncomps1;
            comps = comps1;
        }
    }
}
