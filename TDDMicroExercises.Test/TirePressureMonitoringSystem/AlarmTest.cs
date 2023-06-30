using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Interface;

namespace TDDMicroExercises.Test.TirePressureMonitoringSystem
{
    [TestClass]
    public class AlarmTest
    {
        private Mock<ISensor> _Sensor;
        [TestInitialize]
        public void Init()
        {
            _Sensor = new Mock<ISensor>();
        }
        [TestMethod]
        public void Check_WhenPressureIsLow_ReturnTrue()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(16);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WhenPressureIsHigh_ReturnTrue()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(25);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WhenPressureIsNotHighAndNotLow_ReturnFalse()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(20);
            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WhenPressureIsEqualToLow_ReturnFalse()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(17);
            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WhenPressureIsEqualToHigh_ReturnFalse()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(21);
            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WhenPressureIsEqualToMaxDoubleValue_ReturnTrue()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(Double.MaxValue);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WhenPressureIsEqualToMinDoubleValue_ReturnTrue()
        {
            var alarm = new Alarm(_Sensor.Object);
            _Sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(Double.MinValue);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}
