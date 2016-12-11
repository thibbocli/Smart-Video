using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DTO;
using SmartVideo.Annotations;
using System.Windows.Input;
using BLLLocal;

namespace SmartVideo
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private List<FilmDTO> _listFilm;
        private int _page = -1;
        private int _pageLocal = -1;

        public List<FilmDTO> ListFilm
        {
            get { return _listFilm; }
            set { if(value==_listFilm)
                    return;
                  _listFilm= value;
                  OnPropertyChanged();
            }
        }

        private List<FilmDTO> _listFilmLocal;

        public List<FilmDTO> ListFilmLocal
        {
            get { return _listFilmLocal; }
            set
            {
                if(_listFilmLocal== value)
                    return;
                _listFilmLocal = value;
                OnPropertyChanged();
            }
        }


        public ICommand ListFilmCommandNext { get; set; }
        public ICommand ListFilmCommandPrevious { get; set; }
        public ICommand ListFilmCommandNextLocal { get; set; }
        public ICommand ListFilmCommandPreviousLocal { get; set; }
        public ICommand AlimLocal { get; set; }
        public string IdFilm { get; set; }

        private readonly ServiceReference1.Service1Client Client =new  ServiceReference1.Service1Client();
        private readonly BllLocalItem BLLLocalObj = new BllLocalItem();
        public MainWindowViewModel()
        {
            ListFilmCommandNext = new RelayCommand(c => {
                _page++;
                ListFilm = Client.GetPaginatedFilm(_page).ToList();
            });
            ListFilmCommandPrevious = new RelayCommand(c =>
            {
                if (_page == -1)
                    _page = 0;
                if (_page != 0)
                    _page--;
                ListFilm = Client.GetPaginatedFilm(_page).ToList();
            });
            AlimLocal= new RelayCommand(c =>
            {
                try
                {
                    BLLLocalObj.insertFilm(Client.GetFilm(Int32.Parse(IdFilm)));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message+"\n"+exception.StackTrace, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            ListFilmCommandNextLocal=new RelayCommand(c =>
            {
                _pageLocal++;
                ListFilmLocal = BLLLocalObj.SelectPaginatesFilm(_pageLocal).ToList();
            });
            ListFilmCommandPreviousLocal=new RelayCommand(c =>
            {
                if (_pageLocal == -1)
                    _pageLocal = 0;
                if (_pageLocal != 0)
                    _pageLocal--;
                ListFilmLocal = BLLLocalObj.SelectPaginatesFilm(_pageLocal).ToList(); 
            });
            _listFilm = null;
            _listFilmLocal = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
