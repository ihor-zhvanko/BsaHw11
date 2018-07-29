using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Desktop.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title {
            get { return _title;  }
            set {
                _title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void NotifyPropertyChanged(Expression<Func<object>> target)
        {
            var body = target?.Body as MemberExpression;

            if (body != null) {
                NotifyPropertyChanged(body.Member.Name);
            }
        }
    }
}
