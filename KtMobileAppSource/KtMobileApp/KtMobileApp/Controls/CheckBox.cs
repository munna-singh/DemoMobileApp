using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;

namespace KtMobileApp.Controls
{
    public class CheckedChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs"/> class.
        /// </summary>
        /// <param name = "chkd"></param>
        public CheckedChangedEventArgs(bool chkd)
        {
            this.IsChecked = chkd;
        }

        /// <summary>
        /// Gets the value of the event argument
        /// </summary>
        public bool IsChecked { get; private set; }
    }

    public class CheckBox : View
    {

        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty UncheckedTextProperty =
            BindableProperty.Create("UncheckedText",
                typeof(string),
                typeof(CheckBox),
                false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);


        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty DefaultTextProperty =
            BindableProperty.Create("DefaultText",
                typeof(string),
                typeof(CheckBox),
                false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

        public static readonly BindableProperty CheckedTextProperty =
           BindableProperty.Create("CheckedText",
               typeof(string),
               typeof(CheckBox),
               false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create("Checked",
                typeof(bool),
                typeof(CheckBox),
                false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

#if DEBUG
        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty TestProperty =
            BindableProperty.Create("Test",
                typeof(string),
                typeof(CheckBox),
                "Test", BindingMode.TwoWay);

        

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public string Test
        {
            get
            {
                return (string)GetValue(TestProperty);
            }

            set
            {
                SetValue(TestProperty, value);
            }
        }
#endif

        /// <summary>
        /// Gets or sets a value indicating the checked text.
        /// </summary>
        /// <value>The checked state.</value>
        /// <remarks>
        /// Overwrites the default text property if set when checkbox is checked.
        /// </remarks>
        public string CheckedText
        {
            get
            {
                return (string)GetValue(CheckedTextProperty);
            }

            set
            {
                this.SetValue(CheckedTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        /// <remarks>
        /// Overwrites the default text property if set when checkbox is checked.
        /// </remarks>
        public string UncheckedText
        {
            get
            {
                return (string)GetValue(UncheckedTextProperty);
            }

            set
            {
                this.SetValue(UncheckedTextProperty, value);
            }
        }

        /// <summary>
		/// Gets or sets the text.
		/// </summary>
		public string DefaultText
        {
            get
            {
                return (string)GetValue(DefaultTextProperty);
            }

            set
            {
                this.SetValue(DefaultTextProperty, value);
            }
        }

        /// <summary>
		/// Gets the text.
		/// </summary>
		/// <value>The text.</value>
		public string Text
        {
            get
            {
                return this.Checked
                    ? (string.IsNullOrEmpty(this.CheckedText) ? this.DefaultText : this.CheckedText)
                        : (string.IsNullOrEmpty(this.UncheckedText) ? this.DefaultText : this.UncheckedText);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return (bool)GetValue(CheckedProperty);
            }

            set
            {
                if (this.Checked != value)
                {
                    SetValue(CheckedProperty, value);
                    if (CheckedChanged != null)
                        CheckedChanged.Invoke(this, new CheckedChangedEventArgs(value));
                }
            }
        }

        /// <summary>
        /// The checked changed event.
        /// </summary>
        public event EventHandler<CheckedChangedEventArgs> CheckedChanged;

        /// <summary>
        /// Called when [checked property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">if set to <c>true</c> [oldvalue].</param>
        /// <param name="newvalue">if set to <c>true</c> [newvalue].</param>
        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var checkBox = (CheckBox)bindable;
            checkBox.Checked = (bool)newvalue;
        }
    }
}

