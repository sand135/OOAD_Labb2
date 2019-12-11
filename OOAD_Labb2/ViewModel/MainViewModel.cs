using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OOAD_Labb2.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IAstronautServices IAS;
        private string number = "";
        private bool isBusy;
        public Command ShowCommand { get; set; }
        public ObservableCollection<Astronaut> AstronautList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(IAstronautServices IAS)
        {
            this.IAS = IAS;
            this.AstronautList = new ObservableCollection<Astronaut>();
            ShowCommand = new Command(async () => await PrintData());
        }

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public string NumberOfPeopleInSpace
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }



        public bool IsBusy
        {
            get
            {
                return isBusy; 
            }
            set
            {
                isBusy = value;
                OnPropertyChanged(); 
            }
        }
        
        
        public async Task<SpaceInfoDTO> PrintData()
        {
            IsBusy = true;
            var spaceData = await IAS.GetDataAsync();
            NumberOfPeopleInSpace = spaceData.Number;
            foreach (Astronaut a in spaceData.people)
            {
                AstronautList.Add(a);
            }
            IsBusy = false;

            return spaceData;
        }
    }
}
