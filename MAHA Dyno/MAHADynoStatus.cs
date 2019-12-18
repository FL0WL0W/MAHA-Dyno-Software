using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAHA_Dyno
{
    public class MAHADynoStatus
    {
        public bool LiftBeamUp { get; set; }
        public bool LiftBeamDown { get; set; }
        public bool TorqueTooHigh { get; set; }
        public bool ASMSpeedTooHigh { get; set; }
        public bool AugmentedBrakingEnabled { get; set; }
        public bool PowerTooHigh { get; set; }
        public bool BrakeExcessTemperature { get; set; }
        public bool ImpulseSensorError { get; set; }
        public bool ShortCircuit { get; set; }
        public bool AutoOffsetError { get; set; }
        public bool RollerCovers { get; set; }
        public bool RestrainSystem { get; set; }
        public bool BearingExcessTemperature { get; set; }
        public bool ConverterMotorCurrentAndTemperature { get; set; }
        public bool Reserve { get; set; }
        public bool DrivingMotorRunning { get; set; }
    }
}
