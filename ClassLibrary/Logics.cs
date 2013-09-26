using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class Logics
    {       
        //разделение значений в пределах от 0 до 1 
        public static double ContinPartition(double x, double degree)
        {
            x += 1 / (2 * degree);
            return (x < 0 ? 0 :
                x > (1 / degree) ? 1 :
                x * degree);
        }
       //сглаженное разделение значений
        public static double SmoothPartition(double x, double degree)
        {
            x *= degree;
            if (x <= -0.5) return 0;
            if (x >= 0.5) return 1;

            double f0 = Math.Exp(-1 / (0.5 + x));
            double f1 = Math.Exp(-1 / (0.5 - x));
            return f0 / (f0 + f1);
        }
               
        // Логическое И

        //для 2 элементов
        public static double ContinAnd2(double degree, double x, double y)
        {
            double sx = ContinPartition(x, degree);
            double sy = ContinPartition(y, degree);

            return (x * (1 - sx * (1 - sy)) +
                y * (1 - sy * (1 - sx)));
        }
        //для 4 элементов       
        public static double ContinAnd4(double degree, double x0, double x1, double x2, double x3)
        {
            double s0, s1, s2, s3;
            double prod = 1;

            prod *= (s0 = ContinPartition(x0, degree));
            prod *= (s1 = ContinPartition(x1, degree));
            prod *= (s2 = ContinPartition(x2, degree));
            prod *= (s3 = ContinPartition(x3, degree));

            {
                double sum = 0;
                sum += x0 * (prod + (1 - s0));
                sum += x1 * (prod + (1 - s1));
                sum += x2 * (prod + (1 - s2));
                sum += x3 * (prod + (1 - s3));

                return sum;
            }
        }             
        //для 5 элементов
        public static double ContinAnd5(double degree, double x0, double x1, double x2, double x3, double x4)
        {
            double s0, s1, s2, s3, s4;
            double prod = 1;

            prod *= (s0 = ContinPartition(x0, degree));
            prod *= (s1 = ContinPartition(x1, degree));
            prod *= (s2 = ContinPartition(x2, degree));
            prod *= (s3 = ContinPartition(x3, degree));
            prod *= (s4 = ContinPartition(x4, degree));

            {
                double sum = 0;
                sum += x0 * (prod + (1 - s0));
                sum += x1 * (prod + (1 - s1));
                sum += x2 * (prod + (1 - s2));
                sum += x3 * (prod + (1 - s3));
                sum += x4 * (prod + (1 - s4));

                return sum;
            }
        }
          
        //Логическое ИЛИ              

        //для 2 элементов
        public static double ContinOr2(double degree, double x, double y)
        {
            double sx = ContinPartition(x, degree);
            double sy = ContinPartition(y, degree);

            return (x * (1 - sy * (1 - sx))
                + y * (1 - sx * (1 - sy)));
        }    
        //для 4 элементов
        public static double ContinOr4(double degree, double x0, double x1, double x2, double x3)
        {
            double s0, s1, s2, s3;
            double prod = 1;

            prod *= (s0 = ContinPartition(-x0, degree));
            prod *= (s1 = ContinPartition(-x1, degree));
            prod *= (s2 = ContinPartition(-x2, degree));
            prod *= (s3 = ContinPartition(-x3, degree));

            {
                double sum = 0;
                sum += x0 * (prod + (1 - s0));
                sum += x1 * (prod + (1 - s1));
                sum += x2 * (prod + (1 - s2));
                sum += x3 * (prod + (1 - s3));

                return sum;
            }
        }
        //для 5 элементов
        public static double ContinOr5(double degree, double x0, double x1, double x2, double x3, double x4)
        {
            double s0, s1, s2, s3, s4;
            double prod = 1;

            prod *= (s0 = ContinPartition(-x0, degree));
            prod *= (s1 = ContinPartition(-x1, degree));
            prod *= (s2 = ContinPartition(-x2, degree));
            prod *= (s3 = ContinPartition(-x3, degree));
            prod *= (s4 = ContinPartition(-x4, degree));

            {
                double sum = 0;
                sum += x0 * (prod + (1 - s0));
                sum += x1 * (prod + (1 - s1));
                sum += x2 * (prod + (1 - s2));
                sum += x3 * (prod + (1 - s3));
                sum += x4 * (prod + (1 - s4));

                return sum;
            }
        }
    }
}