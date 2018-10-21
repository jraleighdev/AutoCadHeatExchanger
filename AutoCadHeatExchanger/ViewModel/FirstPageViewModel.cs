using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using AutoCadHeatExchanger.Geometry;
using AutoCadHeatExchanger.Models.HModel;
using AutoCadHeatExchanger.ViewModel.Base;
using Autodesk.AutoCAD.Windows.Data;

namespace AutoCadHeatExchanger.ViewModel
{
    public class FirstPageViewModel : ViewModelBase
    {
        public bool _commandRunning { get; set; }

        public ICommand DrawCommand { get; set; }

        public GeometryManager Geometry { get; set; }

        private HmodelBuildClass hmodel;

        public FirstPageViewModel()
        {
            DrawCommand = new RelayParameterizedCommand( async (parameter) => await RunFirstPageCommands(parameter));
            Geometry = new GeometryManager();
            hmodel = new HmodelBuildClass();
        }

        public async Task RunFirstPageCommands(object parameter)
        {
            await RunCommand(() => _commandRunning, async () =>
            {
                if (parameter.ToString() == "DRAW RECTANGLE")
                {
                    await DrawRectangle();
                }
            });

        }

        private async Task DrawRectangle()
        {
            await Task.Run(() => hmodel.Draw());
        }



    }
}
