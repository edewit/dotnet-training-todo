using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Annotations;

namespace TodoApp
{
    public sealed class TodoItem: INotifyPropertyChanged
    {
        private bool _done;
        public bool Done
        {
            get
            {
                return _done;
            }
            set
            {
                _done = value;
                OnPropertyChanged(nameof(Done));
            }
        }

        public string Description { get; set; }
        public DateTime CreateTime { get; set; }

        public override string ToString()
        {
            return $"Item: '{Description}' created at {CreateTime} is {(Done ? "done": "not done")}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
