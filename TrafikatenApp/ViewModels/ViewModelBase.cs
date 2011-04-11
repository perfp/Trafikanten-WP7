using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TrafikantenApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged 
    {
        private void FirePropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public void FirePropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambda = (LambdaExpression) property;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression) lambda.Body;
                memberExpression = (MemberExpression) unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression) lambda.Body;
            FirePropertyChanged(memberExpression.Member.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
