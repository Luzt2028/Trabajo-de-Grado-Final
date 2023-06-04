using SkiaSharp;
using System;
using SkiaSharp.Views.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using TatianaApp.Helpers;
using TatianaApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using OxyPlot.Xamarin.Forms;
using OxyPlot;
using OxyPlot.Axes;
using Xamarin.Essentials;

namespace TatianaApp.Views
{
    public partial class Metodo1Page : ContentPage
    {
        public Metodo1Page()
        {
            InitializeComponent();
        }
        private SKPoint? selectedPoint;
        private SKPoint[] polygonPoints = new SKPoint[]
        {
            new SKPoint(100, 100),
            new SKPoint(200, 150),
            new SKPoint(300, 200),
            new SKPoint(250, 250),
            new SKPoint(150, 200)
        };
        private void Button_Clicked(object sender, EventArgs e)
        {
            string entry7Text = entry7.Text;
            string entry8Text = entry8.Text;
            string entry9Text = entry9.Text;
            string entry10Text = entry10.Text;
            if (string.IsNullOrEmpty(entry7Text) || string.IsNullOrEmpty(entry8Text) || string.IsNullOrEmpty(entry9Text) || string.IsNullOrEmpty(entry10Text))
            {
                DisplayAlert("Campos vacios", "Llene todos los campos para poder continuar", "Resuelva para poder continuar");
            }
            else 
            {
                label18.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry7Text);
                label19.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry8Text);
                label20.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry9Text);
                label21.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry10Text);
                entry7.IsEnabled = false; 
                entry8.IsEnabled = false; 
                entry9.IsEnabled = false;
                entry10.IsEnabled = false;
                entry1.IsVisible = true;
                entry2.IsVisible = true;
                entry3.IsVisible = true;
                entry4.IsVisible = true;
                entry5.IsVisible = true;
                entry6.IsVisible = true;
                entry11.IsVisible = true;
                entry12.IsVisible = true;
                entry13.IsVisible = true;
                entry14.IsVisible = true;
                showExtraEntriesButton.IsVisible = false;
                showLabelsResults.IsVisible = true;
                entry1.Placeholder = string.Format("Norte del punto {0}", entry7.Text);
                entry2.Placeholder = string.Format("Este del punto {0}", entry7.Text);
                entry3.Placeholder = string.Format("Norte del punto {0}", entry8.Text);
                entry4.Placeholder = string.Format("Este del punto {0}", entry8.Text);
                entry5.Placeholder = string.Format("Norte del punto {0}", entry9.Text);
                entry6.Placeholder = string.Format("Este del punto {0}", entry9.Text);
                entry1.Keyboard = Keyboard.Numeric;
                entry2.Keyboard = Keyboard.Numeric;
                entry3.Keyboard = Keyboard.Numeric;
                entry4.Keyboard = Keyboard.Numeric;
                entry5.Keyboard = Keyboard.Numeric;
                entry6.Keyboard = Keyboard.Numeric;
                entry11.Keyboard = Keyboard.Numeric;
                entry12.Keyboard = Keyboard.Numeric;
                entry13.Keyboard = Keyboard.Numeric;
                entry14.Keyboard = Keyboard.Numeric;
            }

        }

        private void showLabelsResults_Clicked(object sender, EventArgs e)
        {
            // Get the text from each entry
            string entry1Text = entry1.Text;
            string entry2Text = entry2.Text;
            string entry3Text = entry3.Text;
            string entry4Text = entry4.Text;
            string entry5Text = entry5.Text;
            string entry6Text = entry6.Text;
            string entry11Text = entry11.Text;
            string entry12Text = entry12.Text;
            string entry13Text = entry13.Text;
            string entry14Text = entry14.Text;

            if (string.IsNullOrEmpty(entry1Text) || string.IsNullOrEmpty(entry2Text) || string.IsNullOrEmpty(entry3Text) || string.IsNullOrEmpty(entry4Text) || string.IsNullOrEmpty(entry5Text) || string.IsNullOrEmpty(entry6Text) || string.IsNullOrEmpty(entry11Text) || string.IsNullOrEmpty(entry12Text) || string.IsNullOrEmpty(entry13Text) || string.IsNullOrEmpty(entry14Text))
            {
                DisplayAlert("Campos vacios", "Llene todos los campos para poder continuar", "Resuelva para poder continuar");
            }
            else
            {
                if (Double.Parse(entry11Text) <= 180 && Double.Parse(entry12Text) <= 180 && Double.Parse(entry13Text) <= 180 && Double.Parse(entry14Text) <= 180)
                {
                    Method1Helper result = new Method1Helper(entry1Text, entry2Text, entry3Text, entry4Text, entry5Text, entry6Text, entry11Text, entry12Text, entry13Text, entry14Text);
                    Method1Model model = result.ComputeValues();
                    
                    label1.Text = string.Format(" {0}",model.value1);
                    label2.Text = model.value2;
                    label3.Text = model.value3;
                    label4.Text = model.value4;
                    label5.Text = model.value5;
                    label6.Text = model.value6;
                    label7.Text = model.value7;
                    label8.Text = model.value8;
                    label9.Text = model.value9;
                    label10.Text = model.value10;
                    label11.Text = model.value11;
                    label12.Text = model.value12;
                    label13.Text = model.value13;
                    label14.Text = model.value14;
                    label15.Text = model.value15;
                    label16.Text = model.value16;
                    label17.Text = model.value17;
                    label1.IsVisible = true;
                    label2.IsVisible = true;
                    label3.IsVisible = true;
                    label4.IsVisible = true;
                    label5.IsVisible = true;
                    label6.IsVisible = true;
                    label7.IsVisible = true;
                    label8.IsVisible = true;
                    label9.IsVisible = true;
                    label10.IsVisible = true;
                    label11.IsVisible = true;
                    label12.IsVisible = true;
                    label13.IsVisible = true;
                    label14.IsVisible = true;
                    label15.IsVisible = true;
                    label16.IsVisible = true;
                    label17.IsVisible = true;
                    showPlotButton.IsVisible = true;
                }
                else 
                {
                    DisplayAlert("Error en ángulos", "los angulos que inserto son erroneos, ninguno de los ángulos puede ser mayor a 180", "Resuelva para poder continuar");
                    
                }
            }
        }
        private void ShowPlotButton_Clicked(object sender, EventArgs e)
        {
            string ya = Uri.EscapeDataString(entry1.Text);
            string xa = Uri.EscapeDataString(entry2.Text);
            string yb = Uri.EscapeDataString(entry3.Text);
            string xb = Uri.EscapeDataString(entry4.Text);
            string yc = Uri.EscapeDataString(entry5.Text);
            string xc = Uri.EscapeDataString(entry6.Text);
            string aName = Uri.EscapeDataString(entry7.Text);
            string bName = Uri.EscapeDataString(entry8.Text);
            string cName = Uri.EscapeDataString(entry9.Text);
            string dName = Uri.EscapeDataString(entry10.Text);
            string yd = Uri.EscapeDataString(label16.Text);
            string xd = Uri.EscapeDataString(label17.Text);


            Launcher.TryOpenAsync(new Uri($"https://tatiana-cartera.web.app/?xa={xa}&ya={ya}&xb={xb}&yb={yb}&xc={xc}&yc={yc}&xd={xd}&yd={yd}&aName={aName}&bName={bName}&cName={cName}&dName={dName}"));
        }
        

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;
            SKImageInfo info = e.Info;

            canvas.Clear();

            // Dibuja el plano cartesiano
            SKPaint axisPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                IsAntialias = true,
                StrokeWidth = 1
            };

            // Dibuja el eje X
            canvas.DrawLine(0, info.Height / 2, info.Width, info.Height / 2, axisPaint);

            // Dibuja el eje Y
            canvas.DrawLine(info.Width / 2, 0, info.Width / 2, info.Height, axisPaint);

            // Dibuja el polígono en el lienzo
            SKPaint polygonPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Blue,
                IsAntialias = true
            };

            // Coordenadas del polígono en el plano cartesiano
            SKPoint[] polygonPoints = new SKPoint[]
            {
                new SKPoint(100, 100),
                new SKPoint(200, 150),
                new SKPoint(300, 200),
                new SKPoint(250, 250),
                new SKPoint(150, 200)
            };

            // Dibuja el polígono en el lienzo
            canvas.DrawPoints(SKPointMode.Polygon, polygonPoints, polygonPaint);

            // Dibuja la lupa con las coordenadas del punto seleccionado
            if (selectedPoint != null)
            {
                SKPoint point = selectedPoint.Value;

                // Configura los parámetros de la lupa
                float zoomFactor = 2.0f;
                float zoomSize = 100;
                float zoomRadius = zoomSize / 2;

                // Crea una región para recortar el lienzo y enfocar el punto seleccionado
                SKRect zoomRect = new SKRect(point.X - zoomRadius, point.Y - zoomRadius, point.X + zoomRadius, point.Y + zoomRadius);
                canvas.Save();
                canvas.ClipRect(zoomRect);

                // Dibuja el polígono en la lupa
                canvas.Scale(zoomFactor);
                canvas.Translate(-point.X + (info.Width / (2 * zoomFactor)), -point.Y + (info.Height / (2 * zoomFactor)));
                canvas.DrawPoints(SKPointMode.Polygon, polygonPoints, polygonPaint);

                // Restaura la transformación del lienzo
                canvas.Restore();

                // Dibuja el marco de la lupa
                SKPaint framePaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Black,
                    StrokeWidth = 2,
                    IsAntialias = true
                };
                canvas.DrawRect(zoomRect, framePaint);

                // Dibuja las coordenadas de cada punto
                SKPaint textPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.Black,
                    TextSize = 20,
                    IsAntialias = true
                };

                foreach (SKPoint polygonPoint in polygonPoints)
                {
                    string coordinates = $"({polygonPoint.X}, {polygonPoint.Y})";
                    float textWidth = textPaint.MeasureText(coordinates);
                    float textHeight = textPaint.TextSize;
                    float textX = polygonPoint.X - (textWidth / 2);
                    float textY = polygonPoint.Y - zoomRadius - textHeight;
                    canvas.DrawText(coordinates, textX, textY, textPaint);
                }
            }
        }

        private void OnCanvasViewTouch(object sender, SKTouchEventArgs e)
        {
            SKPoint point = e.Location;

            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    selectedPoint = FindSelectedPoint(point);
                    break;
                case SKTouchAction.Released:
                    selectedPoint = null;
                    break;
            }

            ((SKCanvasView)sender).InvalidateSurface();
        }

        private SKPoint? FindSelectedPoint(SKPoint touchPoint)
        {
            // Verifica si el toque está dentro de la región de un punto
            foreach (SKPoint point in polygonPoints)
            {
                float distance = SKPoint.Distance(point, touchPoint);
                if (distance <= 10) // Ajusta este valor según la sensibilidad de selección deseada
                {
                    return point;
                }
            }

            return null;
        }
        private void OnDecimalEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            string newText = e.NewTextValue;

            // Verificar si el último carácter ingresado es un punto
            if (newText.EndsWith("."))
            {
                // Eliminar el punto si hay más de un punto en el texto
                if (newText.IndexOf(".") != newText.LastIndexOf("."))
                    entry.Text = newText.Remove(newText.Length - 1);
            }
            else
            {
                // Eliminar todos los caracteres no numéricos excepto el punto
                entry.Text = new string(newText.Where(c => char.IsDigit(c) || c == '.').ToArray());
            }
        }
    }
}