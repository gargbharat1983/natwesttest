using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interface;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient2
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        private readonly IAlarm _anAlarm;
        public AnAlarmClient2(IAlarm anAlarm)
        {
            _anAlarm = anAlarm;
        }
        private void DoSomething()
        {
            _anAlarm.Check();
            bool isAlarmOn = _anAlarm.AlarmOn;
        }
    }
}
