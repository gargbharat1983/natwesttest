using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interface;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient1
    {
        private readonly IAlarm _anAlarm;
        public AnAlarmClient1(IAlarm anAlarm)
        {
            _anAlarm = anAlarm;
        }
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        public AnAlarmClient1()
        {
            _anAlarm.Check();
            bool isAlarmOn = _anAlarm.AlarmOn;
        }
    }
}
