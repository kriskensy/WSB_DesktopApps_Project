using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public ICommand Command { get; private set; }
        public IconChar Icon { get; private set; } //do pliku z ikoną
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command, IconChar icon)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
            this.Icon = icon;
        }
        #endregion

    }
}
