using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using Gnote.Interfaces;
using Windows.Data.Text;

namespace Gnote.ViewModels
{
    public class NotePageModel : INotifyPropertyChanged
    {
        private string notePath;
        private int _selectedTreeView;
        
        public NotePageModel()
        {
            var store = Ioc.Default.GetRequiredService<IStore>();
            notePath =store.GetNotePath();
        }

        internal bool NoteTreeViewIsExpanded
        {
            get => _selectedTreeView == 0;
        }

        internal bool LabelTreeViewIsExpanded
        {
            get => !NoteTreeViewIsExpanded;
        }

        internal bool LabelTreeViewIsButtom
        {
            get => NoteTreeViewIsExpanded;
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName=null!)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
