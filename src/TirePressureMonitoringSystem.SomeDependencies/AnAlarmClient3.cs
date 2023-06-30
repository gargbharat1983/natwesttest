using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interface;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient3
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        private readonly IAlarm _anAlarm;

        public AnAlarmClient3(IAlarm anAlarm)
        {
            _anAlarm = anAlarm;
        }

        public void DoSomething() 
        {
			_anAlarm.Check();          
        }

		public void DoSomethingElse()
		{
			bool isAlarmOn = _anAlarm.AlarmOn;
		}
    }
}
