﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BehaviorEditor.Command
{
	public class RelayCommand : ICommand
	{
		private readonly Action<object?> execute;
		private readonly Func<object?, bool>? canExecute;

		public RelayCommand(Action<object?> execute, Func<object?, bool>? canexecute = null)
		{
			ArgumentNullException.ThrowIfNull(execute);
			this.execute = execute;
			this.canExecute = canexecute;
		}
		public event EventHandler? CanExecuteChanged;
		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		public bool CanExecute(object? parameter) => canExecute is null || canExecute(parameter);
		public void Execute(object? parameter) => execute(parameter);
	}
}
