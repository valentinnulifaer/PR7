using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WpfApp7;
using МВВМ.Model;
using МВВМ.View;
using МВВМ.ViewModel.Helpers;

namespace МВВМ.ViewModel
{
    internal class GrupiViewModel : BindingHelper
    {
        string fileName = "Grupi.json";
        public BindableCommand AddCommand3 { get; set; }
        public BindableCommand RemoveCommand3 { get; set; }
        public BindableCommand UpdateCommand3 { get; set; }
        public BindableCommand GOTOOCHENKU { get; set; }
        public BindableCommand BACKCommand { get; set; }
        //
        #region Свойства
        private Hurman s;
        public Hurman S
        {
            get { return s; }
            set
            {
                s = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Hurman> group;
        public ObservableCollection<Hurman> HurmanInfo
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public GrupiViewModel()
        {
            HurmanInfo = new ObservableCollection<Hurman>()
            {
                new Hurman("Есть","Гоночная мягкая",50,"Баклажан",100, 30),
                new Hurman("Есть", "Грунтовая", 70,"Черный", 120, 15)
            };
            AddCommand3 = new BindableCommand(_ => AddItems_G());
            RemoveCommand3 = new BindableCommand(_ => RemoveItems_G());
            UpdateCommand3 = new BindableCommand(_ => Update_G());
            GOTOOCHENKU = new BindableCommand(_ => GOTO_OCHENKU());
            BACKCommand = new BindableCommand(_ => BACK());
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
            //ObservableCollection<Hurman> list = JsonConvert.DeserializeObject<ObservableCollection<Hurman>>(jsonString);
            //HurmanInfo = list;
        }
        //
        public void AddItems_G()
        {
            HurmanInfo.Add(new Hurman("Нет","Спортивная жесткая", 69,"Синий", 130, 20));
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        public void RemoveItems_G()
        {
            HurmanInfo.Remove(S);
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
        }

        private void Update_G()
        {
            var i = HurmanInfo.IndexOf(S);
            HurmanInfo[i] = S;
            string jsonString = JsonConvert.SerializeObject(HurmanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        //
        public void GOTO_OCHENKU()
        {
            Ochenku ochenku = new Ochenku();
            ochenku.Show();
        }
        public void BACK()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
