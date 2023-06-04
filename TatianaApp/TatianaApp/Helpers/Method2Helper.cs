using System;
using System.Collections.Generic;
using System.Text;
using TatianaApp.Models;

namespace TatianaApp.Helpers
{
    public class Method2Helper
    {
        private string value1 { get; set; }
        private string value2 { get; set; }
        private string value3 { get; set; }
        private string value4 { get; set; }
        private string value5 { get; set; }
        private string value6 { get; set; }
        private string value7 { get; set; }
        private string value8 { get; set; }
        public Method2Helper(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8) 
        {
            value1 = v1;
            value2 = v2; 
            value3 = v3; 
            value4 = v4; 
            value5 = v5; 
            value6 = v6;
            value7 = v7;
            value8 = v8;
        }
        public static string ConvertirAGrados(double coordenada)
        {
            // Obtenemos el signo de la coordenada (positivo o negativo)
            string signo = coordenada >= 0 ? "" : "-";

            // Convertimos el valor absoluto de la coordenada a grados, minutos y segundos
            double coordenadaAbsoluta = Math.Abs(coordenada);
            int grados = (int)coordenadaAbsoluta;
            double minutosDecimales = (coordenadaAbsoluta - grados) * 60;
            int minutos = (int)minutosDecimales;
            double segundosDecimales = (minutosDecimales - minutos) * 60;
            int segundos = (int)segundosDecimales;

            // Creamos la representación del string en grados
            string resultado = $"{signo}{grados}° {minutos}' {segundos}\"";

            return resultado;
        }
        public Method2Model ComputeValues()
        {
            double norte1 = Double.Parse(value1);
            double norte2 = Double.Parse(value2);
            double norte3 = Double.Parse(value3);
            double este1 = Double.Parse(value4);
            double este2 = Double.Parse(value5);
            double este3 = Double.Parse(value6);
            double anguloAlfa = Double.Parse(value7);
            double anguloBeta = Double.Parse(value8);

            Method2Model objectMethod2 = new Method2Model();
            //Distancias entre puntos
            double distancia1 = Math.Sqrt((Math.Pow((norte3 - norte2), 2)) + (Math.Pow((este3 - este2), 2)));
            double distancia2 = Math.Sqrt((Math.Pow((norte3 - norte1), 2)) + (Math.Pow((este3 - este1), 2)));
            double distancia3 = Math.Sqrt((Math.Pow((norte2 - norte1), 2)) + (Math.Pow((este2 - este1), 2)));
            objectMethod2.value1 = distancia1.ToString();
            objectMethod2.value2 = distancia2.ToString();
            objectMethod2.value3 = distancia3.ToString();

            // Calculo de azimut
            double diferenciaNorteAzimut1 = norte3 - norte2;
            double diferenciaNorteAzimut2 = norte3 - norte1;
            double diferenciaNorteAzimut3 = norte2 - norte1;
            double diferenciaEsteAzimut1 = este3 - este2;
            double diferenciaEsteAzimut2 = este3 - este1;
            double diferenciaEsteAzimut3 = este2 - este1;
            double azimut1 = azimut(1, Math.Atan(diferenciaEsteAzimut1 / diferenciaNorteAzimut1) * (180 / Math.PI), norte1, norte2, norte3, este1, este2, este3);
            double azimut2 = azimut(2, Math.Atan(diferenciaEsteAzimut2 / diferenciaNorteAzimut2) * (180 / Math.PI), norte1, norte2, norte3, este1, este2, este3);
            double azimut3 = azimut(3, Math.Atan(diferenciaEsteAzimut3 / diferenciaNorteAzimut3) * (180 / Math.PI), norte1, norte2, norte3, este1, este2, este3);

            objectMethod2.value4 = ConvertirAGrados(azimut1);
            objectMethod2.value5 = ConvertirAGrados(azimut2);
            objectMethod2.value6 = ConvertirAGrados(azimut3);

            //Calculo de los angulos

            int formulaUsada = 1;
            double Angulo1 = 360 - azimut2 + azimut3;
            double Angulo2 = azimut1 - (azimut3 + 180);
            double Angulo3 = azimut2 - azimut1;
            Double sumatoriaAngulos = Math.Round(Angulo1 + Angulo2 + Angulo3);
            if (sumatoriaAngulos > 180 || sumatoriaAngulos < 179)
            {
                formulaUsada = 2;
                Angulo1 = azimut2 - azimut3;
                Angulo2 = (azimut3 + 180) - azimut1;
                Angulo3 = azimut1 - azimut2;
                sumatoriaAngulos = Math.Round(Angulo1 + Angulo2 + Angulo3);
            }
            if (sumatoriaAngulos > 180 || sumatoriaAngulos < 179)
            {
                formulaUsada = 3;
                Angulo1 = azimut2 - azimut3;
                Angulo2 = azimut1 + (azimut3 - 180);
                Angulo3 = (azimut2 - 180) + (azimut1 + 180);
                sumatoriaAngulos = Math.Round(Angulo1 + Angulo2 + Angulo3);
            }
            if (sumatoriaAngulos > 180 && sumatoriaAngulos < 179)
            {
                formulaUsada = 4;
                Angulo1 = azimut3 - azimut2;
                Angulo2 = (azimut3 + 180) + 360 + azimut1;
                Angulo3 = (azimut2 + 180) - (azimut1 + 180);
            }
            objectMethod2.value7 = ConvertirAGrados(Angulo1);
            objectMethod2.value8 = ConvertirAGrados(Angulo2);
            objectMethod2.value9 = ConvertirAGrados(Angulo3);

            // Calculo del valor S
            double operacion = (Angulo1 - (anguloAlfa + anguloBeta)) / 2;
            double s = Math.Tan((Math.PI / 180) * operacion);
            objectMethod2.value10 = ConvertirAGrados(s);

            //Calculo de delta
            double y = (distancia2 * Math.Sin((Math.PI / 180) * anguloBeta)) / (distancia3 * Math.Sin((Math.PI / 180) * anguloAlfa));
            double tan45 = (1 + y) / (1 - y);
            double Delta = Math.Atan(s / tan45) * 180 / Math.PI;
            objectMethod2.value11 = ConvertirAGrados(Delta);

            //Calculo de X y Y

            double X = operacion + Delta;
            double Y = operacion - Delta;
            objectMethod2.value12 = ConvertirAGrados(X);
            objectMethod2.value13 = ConvertirAGrados(Y);

            //Calculo de Azimut
            double anguloThetaAzimut = 180 - (anguloAlfa + X);
            double anguloOmegaAzimut = 180 - (anguloBeta + Y);
            objectMethod2.value14 = ConvertirAGrados(anguloOmegaAzimut);
            objectMethod2.value15 = ConvertirAGrados(anguloThetaAzimut);
            //Suma de angulos
            objectMethod2.value16 = ConvertirAGrados(anguloThetaAzimut + anguloOmegaAzimut);

            double Azimut = 0;
            if (formulaUsada == 1)
            {
                Azimut = azimut3 + anguloOmegaAzimut;
            }
            if (formulaUsada == 2)
            {
                Azimut = (azimut2 + anguloThetaAzimut) + 360;
            }
            if (formulaUsada == 3)
            {
                Azimut = azimut3 - anguloOmegaAzimut;
            }
            if (formulaUsada == 4)
            {
                Azimut = azimut2 - anguloThetaAzimut;
            }

            objectMethod2.value17 = ConvertirAGrados(Azimut);

            //Calculo distancia entre tercer pounto y punto por hallar
            double distFaltante = (Math.Sin((Math.PI / 180) * Y)*distancia3)/Math.Sin((Math.PI / 180) * anguloBeta);
            objectMethod2.value18 = distFaltante.ToString();

            //Calculo de las proyecciones norte y este

            double proyNorte = Math.Cos((Math.PI/180) *  Azimut) * distFaltante;
            double proyEste = Math.Sin((Math.PI / 180) * Azimut) * distFaltante;
            double CoordNort = norte1 + proyNorte;
            double CoordEste = este1 + proyEste;
            objectMethod2.value19 = CoordNort.ToString();
            objectMethod2.value20 = CoordEste.ToString();
            return objectMethod2;
        }

        private double azimut(int typeAzimut,double azimut, double norte1 , double norte2, double norte3, double este1, double este2, double este3) 
        {
            double returnAzimut = azimut;
            if (typeAzimut == 1) 
            {
                if ((norte3 - norte2) > 0 && (este3 - este2) > 0)
                {
                    returnAzimut = azimut;
                    return returnAzimut;
                }
                if ((norte3 - norte2) < 0 && (este3 - este2) > 0)
                {
                    returnAzimut = azimut + 180;
                    return returnAzimut;
                }
                if ((norte3 - norte2) < 0 && (este3 - este2) < 0)
                {
                    returnAzimut = azimut + 180;
                    return returnAzimut;
                }
                if ((norte3 - norte2) > 0 && (este3 - este2) < 0)
                {
                    returnAzimut = azimut + 360;
                    return returnAzimut;
                }
            }
            if (typeAzimut == 2)
            {
                if ((norte3 - norte1) > 0 && (este3 - este1) > 0)
                {
                    returnAzimut = azimut;
                    return returnAzimut;
                }
                if ((norte3 - norte1) < 0 && (este3 - este1) > 0)
                {
                    returnAzimut = azimut + 180;
                    return returnAzimut;
                }
                if ((norte3 - norte1) < 0 && (este3 - este1) < 0)
                {
                    returnAzimut = azimut + 180;
                    return returnAzimut;
                }
                if ((norte3 - norte1) > 0 && (este3 - este1) < 0)
                {
                    returnAzimut = azimut + 360;
                    return returnAzimut;
                }
            }
            if (typeAzimut == 3)
            {
                if ((norte2 - norte1) > 0 && (este2 - este1) > 0)
                {
                    returnAzimut = azimut;
                    return returnAzimut;
                }
                if ((norte2 - norte1) < 0 && (este2 - este1) > 0)
                {
                    returnAzimut = azimut + 180;
                    return returnAzimut;
                }
                if ((norte2 - norte1) < 0 && (este2 - este1) < 0)
                {
                    returnAzimut = azimut + 180;
                    return returnAzimut;
                }
                if ((norte2 - norte1) > 0 && (este2 - este1) < 0)
                {
                    returnAzimut = azimut + 360;
                    return returnAzimut;
                }
            }
            return returnAzimut;
        }
    }
}
