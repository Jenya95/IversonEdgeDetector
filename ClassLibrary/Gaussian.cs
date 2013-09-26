using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class Gaussian
    {
        //Функция Гаусса
        public static double G(double x, double s)
        {
            return Math.Exp(-(x * x) / (2 * s * s)) / (Math.Sqrt(2 * Math.PI) * s);
        }
        //1 производная
        public static double dG(double x, double s)
        {
            return -x * G(x, s) / (s * s);
        }
        //2 производная
        public static double d2G(double x, double s)
        {
            double s2 = s * s, s4 = s2 * s2;
            return (x * x - s2) * G(x, s) / s4;
        }
        //3 производная
        public static double d3G(double x, double s)
        {
            double s2 = s * s, s4 = s2 * s2, s6 = s4 * s2;
            return -x * (x * x - 3 * s2) * G(x, s) / (s6);
        }
        //4 производная
        public static double d4G(double x, double s)
        {
            double s2 = s * s, s4 = s2 * s2, s8 = s4 * s4;
            return (x * x * (x * x - 6 * s2) + 3 * s4) * G(x, s) / (s8);
        }
    }
}
