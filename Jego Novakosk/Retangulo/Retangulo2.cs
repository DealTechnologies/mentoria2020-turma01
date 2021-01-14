using System;


    public class Retangulo2
    {
        public double comprimento;
        public double largura;

        public double Area(){
            return comprimento * largura;
        }

        public double Perimetro(){
            return Math.Pow(comprimento,2) + Math.Pow(largura,2);
        }

        public double Diagonal(){
            return Math.Sqrt(Math.Pow(comprimento,2) + Math.Pow(largura,2));
        }
        
    }
