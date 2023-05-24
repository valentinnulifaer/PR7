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
    internal class MainViewModel : BindingHelper
    {
        string fileName = "FIO.json";
        public BindableCommand AddCommand { get; set; }
        public BindableCommand RemoveCommand { get; set; }
        public BindableCommand UpdateCommand { get; set; }
        public BindableCommand GOTOOCHENKU { get; set; }
        public BindableCommand GOTO_group {get; set; }
        #region Свойства
        private Herman selected;
        public Herman Selected
        { 
          get { return selected; }
          set 
          {
                selected = value;
                OnPropertyChanged();           
          }
        }
        private ObservableCollection<Herman> fio;
        public ObservableCollection<Herman> HermanInfo
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged();

            }
        }
        #endregion
        public MainViewModel()
        {
            AddCommand = new BindableCommand(_ => AddItems_FIO());
            RemoveCommand = new BindableCommand(_ => RemoveItems());
            UpdateCommand = new BindableCommand(_=> Update());
            GOTOOCHENKU = new BindableCommand(_ =>GOTO_OCHENKU());
            GOTO_group = new BindableCommand(_ => GOTO_Group());
            string jsonString = JsonConvert.SerializeObject(HermanInfo);
            //ObservableCollection<Herman> list = JsonConvert.DeserializeObject<ObservableCollection<Herman>>(jsonString);
           // HermanInfo = list;
            HermanInfo = new ObservableCollection<Herman>()
            {
                new Herman("KIA","RIO","2012"),
                new Herman("Mercedes","Benz-s","2007")
            };
            File.WriteAllText(fileName, jsonString);
        }
        //
        public void RemoveItems() 
        {
            HermanInfo.Remove(Selected);
            string jsonString = JsonConvert.SerializeObject(HermanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        public void AddItems_FIO()
        {
            HermanInfo.Add(new Herman("Nissan", "Quashqai", null));
            string jsonString = JsonConvert.SerializeObject(HermanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        private void Update()
        {
            var i = HermanInfo.IndexOf(Selected);
            HermanInfo[i] = Selected;
            string jsonString = JsonConvert.SerializeObject(HermanInfo);
            File.WriteAllText(fileName, jsonString);
        }
        //
        public void GOTO_Group()
        {
            Gruppi gruppi = new Gruppi();
            gruppi.Show();
        }
        public void GOTO_OCHENKU()
        {   Ochenku ochenku = new Ochenku();
            ochenku.Show();
        }
    }
}
