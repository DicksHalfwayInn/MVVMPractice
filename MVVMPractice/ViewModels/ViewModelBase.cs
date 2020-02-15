using MVVMPractice.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MVVMPractice.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        #region Protected Members

        /// <summary>
        /// A global lock for property checks so prevent locking on different instances of expressions.
        /// Considering how fast this check will always be it isn't an issue to globally lock all callers.
        /// </summary>
        protected object mPropertyValueCheckLock = new object();

        #endregion

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        //protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value))
        //        return false;
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}

        //public string Error
        //{
        //    get => MError;
        //    protected set
        //    {
        //        if (MError == value)
        //            return;
        //        MError = value;
        //        OnPropertyChanged(nameof(Error));
        //        OnPropertyChanged("HasErrors");
        //        OnPropertyChanged("AllErrors");
        //    }
        //}

        //public string AllErrors => string.Join("\r\n", MErrorList.Select(s => s.Value).ToArray());

        //public virtual bool HasErrors => MErrorList.Count > 0;

        //protected Dictionary<string, string> MErrorList { get; set; } = new Dictionary<string, string>();
        //protected string MError { get; set; } = string.Empty;
        //public List<DelegateCommand> Commands { get; set; } = new List<DelegateCommand>();

        //public virtual string this[string columnName]
        //{
        //    get
        //    {
        //        Error = Validate(columnName);
        //        UpdateErrorList(columnName, Error);
        //        return Error;
        //    }
        //}

        //protected void UpdateErrorList(string columnName, string error)
        //{
        //    if (MErrorList.ContainsKey(columnName))
        //    {
        //        if (string.IsNullOrEmpty(error))
        //            MErrorList.Remove(columnName);
        //        else
        //            MErrorList[columnName] = error;
        //    }
        //    else if (!string.IsNullOrEmpty(error))
        //        MErrorList.Add(columnName, error);
        //    OnPropertyChanged("HasErrors");
        //    OnPropertyChanged("AllErrors");
        //}

        //protected virtual string Validate(string propertyName)
        //{
        //    string str = ValidateByAnnotations(propertyName);
        //    return !string.IsNullOrEmpty(str) ? str : OnValidate(propertyName);
        //}

        //public string ValidateModel(object T)
        //{
        //    var props = T.GetType().GetProperties();
        //    string error = string.Empty;

        //    foreach (PropertyInfo prop in props)
        //    {
        //        error += Validate(prop.Name);
        //    }

        //    return error;
        //}

        //protected virtual string OnValidate(string propertyName)
        //{
        //    return string.Empty;
        //}

        //private string ValidateByAnnotations(string propertyName)
        //{
        //    ValidationContext validationContext = new ValidationContext(this, null, null)
        //    {
        //        MemberName = propertyName
        //    };
        //    Collection<ValidationResult> source = new Collection<ValidationResult>();
        //    if (Validator.TryValidateObject(this, validationContext, source, true))
        //        return string.Empty;
        //    ValidationResult validationResult = source.SingleOrDefault(r => r.MemberNames.Any(m => string.Equals(m, propertyName)));
        //    return validationResult != null ? validationResult.ErrorMessage : string.Empty;
        //}

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChangedEventHandler propertyChanged = PropertyChanged;
        //    if (propertyChanged == null)
        //        return;
        //    propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    foreach (DelegateCommand command in Commands)
        //    {
        //        command.InvokeCanExecuteChanged();
        //    }
        //}

        //public class PropertyName
        //{
        //    private const string hasErrors = "HasErrors";
        //    private const string error = "Error";
        //    private const string allErrors = "AllErrors";

        //    public static string HasErrors => hasErrors;

        //    public static string Error => error;

        //    public static string AllErrors => allErrors;
        //}
    }
}
