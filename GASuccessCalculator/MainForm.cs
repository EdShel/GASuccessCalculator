using GASuccessCalculator.Model;
using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GASuccessCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void RedrawPlot(int variant)
        {
            var plotSeries = cPlot.Series[0];
            plotSeries.Points.Clear();

            var dayParams = typeof(DayInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(var day in DataGenerator.Generate(variant))
            {
                Expression exp = new Expression(tFormula.Text, EvaluateOptions.IgnoreCase);
                foreach(var property in dayParams)
                {
                    exp.Parameters[property.Name] = property.GetValue(day);
                }

                double value = Convert.ToDouble(exp.Evaluate());

                plotSeries.Points.AddXY(day.Date.Day, value);
            }
        }

        private void RedrawPlot(object sender, EventArgs e)
        {
            try
            {
                RedrawPlot((int)(nVariant).Value);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
