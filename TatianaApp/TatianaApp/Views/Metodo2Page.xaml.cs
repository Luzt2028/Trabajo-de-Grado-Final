using OxyPlot.Xamarin.Forms;
using OxyPlot;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Linq;
using TatianaApp.Helpers;
using TatianaApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TatianaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Metodo2Page : ContentPage
    {
        Method2Model model { get; set; }
        private SKPoint? selectedPoint;
        private SKPoint[] polygonPoints = new SKPoint[]
        {
            new SKPoint(100, 100),
            new SKPoint(200, 150),
            new SKPoint(300, 200),
            new SKPoint(250, 250),
            new SKPoint(150, 200)
        };
        public Metodo2Page()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            string entry1Text = entry1.Text;
            string entry2Text = entry2.Text;
            string entry3Text = entry3.Text;
            string entry4Text = entry4.Text;
            
            if (string.IsNullOrEmpty(entry1Text) || string.IsNullOrEmpty(entry2Text) || string.IsNullOrEmpty(entry3Text) || string.IsNullOrEmpty(entry4Text))
            {
                DisplayAlert("Campos vacios", "Llene todos los campos para poder continuar", "Resuelva para poder continuar");
            }
            else
            {
                label1.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry1Text);
                label2.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry2Text);
                label3.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry3Text);
                label4.Text = string.Format("Nombre de Placa o punto de armada ({0})", entry4Text);
                entry1.IsEnabled = false;
                entry2.IsEnabled = false;
                entry3.IsEnabled = false;
                entry4.IsEnabled = false;
                entry5.IsVisible = true;
                entry6.IsVisible = true;
                entry7.IsVisible = true;
                entry8.IsVisible = true;
                entry9.IsVisible = true;
                entry10.IsVisible = true;
                entry11.IsVisible = true;
                entry12.IsVisible = true;
                entry5.Placeholder = string.Format("Norte del punto {0}", entry1Text);
                entry6.Placeholder = string.Format("Norte del punto {0}", entry2Text);
                entry7.Placeholder = string.Format("Norte del punto {0}", entry3Text);
                entry8.Placeholder = string.Format("Este del punto {0}", entry1Text);
                entry9.Placeholder = string.Format("Este del punto {0}", entry2Text);
                entry10.Placeholder = string.Format("Este del punto {0}", entry3Text);
                showExtraEntriesButton.IsVisible = false;
                showLabelsResults.IsVisible = true;
                entry5.Keyboard = Keyboard.Numeric;
                entry6.Keyboard = Keyboard.Numeric;
                entry7.Keyboard = Keyboard.Numeric;
                entry8.Keyboard = Keyboard.Numeric;
                entry9.Keyboard = Keyboard.Numeric;
                entry10.Keyboard = Keyboard.Numeric;
                entry11.Keyboard = Keyboard.Numeric;
                entry12.Keyboard = Keyboard.Numeric;
            }
        }

        private void showLabelsResults_Clicked(object sender, EventArgs e)
        {
            // Get the text from each entry
            string entry5Text = entry5.Text;
            string entry6Text = entry6.Text;
            string entry7Text = entry7.Text;
            string entry8Text = entry8.Text;
            string entry9Text = entry9.Text;
            string entry10Text = entry10.Text;
            string entry11Text = entry11.Text;
            string entry12Text = entry12.Text;

            if (string.IsNullOrEmpty(entry5Text) || string.IsNullOrEmpty(entry6Text) || string.IsNullOrEmpty(entry7Text) || string.IsNullOrEmpty(entry8Text) || string.IsNullOrEmpty(entry9Text) || string.IsNullOrEmpty(entry10Text) || string.IsNullOrEmpty(entry11Text) || string.IsNullOrEmpty(entry12Text))
            {
                DisplayAlert("Campos vacios", "Llene todos los campos para poder continuar", "Resuelva para poder continuar");
            }
            else
            {
                Method2Helper result = new Method2Helper(entry5Text, entry6Text, entry7Text, entry8Text, entry9Text, entry10Text, entry11Text, entry12Text);
                model = result.ComputeValues();
                label5.Text = string.Format(" {0}", model.value1);
                label6.Text = model.value2;
                label7.Text = model.value3;
                label8.Text = model.value4;
                label9.Text = model.value5;
                label10.Text = model.value6;
                label11.Text = model.value7;
                label12.Text = model.value8;
                label13.Text = model.value9;
                label14.Text = model.value10;
                label15.Text = model.value11;
                label16.Text = model.value12;
                label17.Text = model.value13;
                label18.Text = model.value14;
                label19.Text = model.value15;
                label20.Text = model.value16;
                label21.Text = model.value17;
                label22.Text = model.value18;
                label23.Text = model.value19;
                label24.Text = model.value20;
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
                label18.IsVisible = true;
                label19.IsVisible = true;
                label20.IsVisible = true;
                label21.IsVisible = true;
                label22.IsVisible = true;
                label23.IsVisible = true;
                label24.IsVisible = true;

                showPlotButton.IsVisible = true;

            }
        }
        private void ShowPlotButton_Clicked(object sender, EventArgs e)
        {
            string ya = Uri.EscapeDataString(entry5.Text);
            string xa = Uri.EscapeDataString(entry8.Text);
            string yb = Uri.EscapeDataString(entry6.Text);
            string xb = Uri.EscapeDataString(entry9.Text);
            string yc = Uri.EscapeDataString(entry7.Text);
            string xc = Uri.EscapeDataString(entry10.Text);
            string aName = Uri.EscapeDataString(entry1.Text);
            string bName = Uri.EscapeDataString(entry2.Text);
            string cName = Uri.EscapeDataString(entry3.Text);
            string dName = Uri.EscapeDataString(entry4.Text);
            string yd = Uri.EscapeDataString(label23.Text);
            string xd = Uri.EscapeDataString(label24.Text);


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