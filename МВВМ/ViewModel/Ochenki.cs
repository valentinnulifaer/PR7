using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp7;
using МВВМ.Model;
using МВВМ.View;
using МВВМ.ViewModel.Helpers;

namespace МВВМ.ViewModel
{
    internal class Ochenki : BindingHelper
    {
        string fileName = "Ochenki.json";
        public BindableCommand AddCommand2 { get; set; }
        public BindableCommand RemoveCommand2 { get; set; }
        public BindableCommand UpdateCommand2 { get; set; }
        public BindableCommand BACKCommand { get; set; }
        public BindableCommand GOTO_group { get; set; }
        #region Свойства
        private Hurman sele;
        public Hurman Sele
        {
            get { return sele; }
            set
            {
                sele = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Hurman> o;
        public ObservableCollection<Hurman> HurmanInfo
        {
            get { return o; }
            set
            {
                o = value;
                OnPropertyChanged();

            }
        }
        #endregion
        public Ochenki()
        {
           
            AddCommand2 = new BindableCommand(_ => AddItems_O());
            RemoveCommand2 = new BindableCommand(_ => RemoveItems_O());
            UpdateCommand2 = new BindableCommand(_ => Update_O());
            BACKCommand = new BindableCommand(_ => BACK());
            GOTO_group = new BindableCommand(_ => GOTO_Group());
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            ObservableCollection<Hurman> list = JsonConvert.DeserializeObject<ObservableCollection<Hurman>>(jsonString);
            HurmanInfo = new ObservableCollection<Hurman>()
            {
                new Hurman(1,"Хорошее ТО"),
                new Hurman(2,"Плохое ТО")
            };
            File.WriteAllText(fileName, jsonString);
        }
        //
        public void AddItems_O()
        {
            HurmanInfo.Add(new Hurman(3,"Среднее ТО"));
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        public void RemoveItems_O()
        {
            HurmanInfo.Remove(Sele);
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
        }

        private void Update_O()
        {
            var i = HurmanInfo.IndexOf(Sele);
            HurmanInfo[i] = Sele;
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        //
        public void GOTO_Group()
        {
            Gruppi gruppi = new Gruppi();
            gruppi.Show();
        }
        public void BACK()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
