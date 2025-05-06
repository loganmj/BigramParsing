using System.Windows;
using System.Windows.Controls;

namespace BigramParser.UserControls
{
    /// <summary>
    /// Interaction logic for StringEditor.xaml
    /// </summary>
    public partial class StringEditor : UserControl
    {
        #region Properties

        /// <summary>
        /// The string value content of the input textbox.
        /// </summary>
        public string TextContent
        {
            get => (string)GetValue(TextContentProperty);
            set => SetValue(TextContentProperty, value);
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Exposes the TextContent property as a Dependency Property, allowing for data binding.
        /// </summary>
        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register(nameof(TextContent),
                                        typeof(string),
                                        typeof(StringEditor),
                                        new PropertyMetadata(string.Empty));

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public StringEditor()
        {
            InitializeComponent();
        }

        #endregion
    }
}
