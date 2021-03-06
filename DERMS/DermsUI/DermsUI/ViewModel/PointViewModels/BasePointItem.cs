﻿using dCom.Utils;
using DERMSCommon.SCADACommon;
using DermsUI.Resources;
//using Modbus;
//using Modbus.FunctionParameters;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace DermsUI.ViewModel.PointViewModel
{
	internal class BasePointItem : BindableBase, IDataErrorInfo
	{
		protected PointType type;
		protected ushort address;
		private DateTime timestamp = DateTime.Now;
		private string name = string.Empty;
        private double gid;
		private ushort rawValue;
		private double commandedValue;
		protected AlarmType alarm;

		protected IFunctionExecutor commandExecutor;
		protected IConfiguration configuration;

		protected Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

		protected IStateUpdater stateUpdater;
		protected IConfigItem configItem;

		/// <summary>
		/// Command that is executed when write button is clicked on control window;
		/// Command should create write command parameters and provide it to FunctionFactory
		/// </summary>
		public RelayCommand WriteCommand { get; set; }

		/// <summary>
		/// Command that is executed when read button is clicked on control window;
		/// Command should create read command parameters and provide it to FunctionFactory
		/// </summary>
		public RelayCommand ReadCommand { get; set; }

		public BasePointItem(IConfigItem c, IFunctionExecutor commandExecutor, IStateUpdater stateUpdater, IConfiguration configuration, int i)
		{
			this.configItem = c;
			this.commandExecutor = commandExecutor;
			this.stateUpdater = stateUpdater;
			this.configuration = configuration;

			this.type = c.RegistryType;
			this.address = (ushort)(c.StartAddress+i);
            this.gid = configItem.Gid;
			this.name = $"{configItem.Description}";
			this.rawValue = configItem.DefaultValue;
		//	commandExecutor.UpdatePointEvent += CommandExecutor_UpdatePointEvent;
			WriteCommand = new RelayCommand(WriteCommand_Execute, WriteCommand_CanExecute);
			ReadCommand = new RelayCommand(ReadCommand_Execute);
		}

		protected virtual bool WriteCommand_CanExecute(object obj)
		{
			return false;
		}

		protected virtual void CommandExecutor_UpdatePointEvent(PointType type, ushort pointAddres, ushort newValue)
		{
			// Intentionally left blank
		}

		/// <summary>
		/// Method that is executed when write button is clicked on control window;
		/// Method should create write command parameters and provide it to FunctionFactory
		/// </summary>
		/// <param name="obj">Not used</param>
		protected virtual void WriteCommand_Execute(object obj)
		{
		}

		/// <summary>
		/// Method that is executed when read button is clicked on control window;
		/// Method should create read command parameters and provide it to FunctionFactory
		/// </summary>
		/// <param name="obj">Not used</param>
		private void ReadCommand_Execute(object obj)
		{
			try
			{
				
		//		ModbusReadCommandParameters p = new ModbusReadCommandParameters(6, (byte)GetReadFunctionCode(type), address, 1, configuration);
			//	IModbusFunction fn = FunctionFactory.CreateModbusFunction(p);
				//this.commandExecutor.EnqueueCommand(fn);
			}
			catch (Exception ex)
			{
				string message = $"{ex.TargetSite.ReflectedType.Name}.{ex.TargetSite.Name}: {ex.Message}";
				this.stateUpdater.LogMessage(message);
			}
		}


		private ModbusFunctionCode? GetReadFunctionCode(PointType registryType)
		{
			switch (registryType)
			{
				case PointType.DIGITAL_OUTPUT: return ModbusFunctionCode.READ_COILS;
				case PointType.DIGITAL_INPUT: return ModbusFunctionCode.READ_DISCRETE_INPUTS;
				case PointType.ANALOG_INPUT: return ModbusFunctionCode.READ_INPUT_REGISTERS;
				case PointType.ANALOG_OUTPUT: return ModbusFunctionCode.READ_HOLDING_REGISTERS;
				case PointType.HR_LONG: return ModbusFunctionCode.READ_HOLDING_REGISTERS;
				default: return null;
			}
		}

		protected ModbusFunctionCode? GetWriteFunctionCode(PointType registryType)
		{
			switch (registryType)
			{
				case PointType.DIGITAL_OUTPUT: return ModbusFunctionCode.WRITE_SINGLE_COIL;
				case PointType.ANALOG_OUTPUT: return ModbusFunctionCode.WRITE_SINGLE_REGISTER;
				default: return null;
			}
		}

		#region Properties

		public PointType Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
				OnPropertyChanged("Type");
			}
		}

		/// <summary>
		/// Address of point on MdbSim Simulator
		/// </summary>
		public ushort Address
		{
			get
			{
				return address;
			}

			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		public DateTime Timestamp
		{
			get
			{
				return timestamp;
			}

			set
			{
				timestamp = value;
				OnPropertyChanged("Timestamp");
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}
        public double Gid
        {
            get
            {
                return gid;
            }

            set
            {
                gid = value;
            }
        }
        public virtual string DisplayValue
		{
			get
			{
				return string.Empty;
			}
		}
        public virtual string DisplayValueGid
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Value that is sent on MdbSim simulator
        /// </summary>
        public double CommandedValue
		{
			get
			{
				return commandedValue;
			}

			set
			{
				commandedValue = value;
				OnPropertyChanged("CommandedValue");
			}
		}

		/// <summary>
		/// Raw value, read from MdbSim
		/// </summary>
		public virtual ushort RawValue
		{
			get
			{
				return rawValue;
			}
			set
			{
				rawValue = value;
				OnPropertyChanged("RawValue");
			}
		}

		#endregion Properties

		#region Input validation

		public string Error
		{
			get
			{
				return string.Empty;
			}
		}

		public AlarmType Alarm
		{
			get
			{
				return alarm;
			}
		}

		public string this[string columnName]
		{
			get
			{
				string message = string.Empty;
				if (columnName == "CommandedValue")
				{
					if (commandedValue > configItem.EGU_Max)
					{
						message = $"Entered value cannot be greater than {configItem.EGU_Max}.";
					}
					if (commandedValue < configItem.EGU_Min)
					{
						message = $"Entered value cannot be lower than {configItem.EGU_Min}.";
					}
				}
				return message;
			}
		}

		#endregion Input validation
	}
}