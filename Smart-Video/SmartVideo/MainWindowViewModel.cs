using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DTO;
using SmartVideo.Annotations;
using System.Windows.Input;

namespace SmartVideo
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private List<FilmDTO> _listFilm;
        private int page = -1;

        public List<FilmDTO> ListFilm
        {
            get { return _listFilm; }
            set { if(value==_listFilm)
                    return;
                  _listFilm= value;
                  OnPropertyChanged();
            }
        }

        public ICommand ListFilmCommandNext { get; set; }
        public ICommand ListFilmCommandPrevious { get; set; }

        private readonly ServiceReference1.Service1Client Client =new  ServiceReference1.Service1Client();
        public MainWindowViewModel()
        {
            ListFilmCommandNext = new RelayCommand(C => {
                page++;
                ListFilm = Client.GetPaginatedFilm(page).ToList();
            });
            ListFilmCommandPrevious = new RelayCommand(C =>
            {
                if (page == -1)
                    page = 0;
                if (page != 0)
                    page--;
                ListFilm = Client.GetPaginatedFilm(page).ToList();
            });
            _listFilm = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
