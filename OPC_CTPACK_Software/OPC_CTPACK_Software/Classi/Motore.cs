using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Motore
    {
        string MotorModel;
        string RatedPower;
        string RatedVoltage;
        string RatedSpeed;
        string RatedCurrent;
        string RatedTorque;
        string PoleCount;
        string PeakCurrent;
        string TorqueCostant;
        string VoltageCostant;
        string Resistance;
        string Inductance;

        public Motore(string MotorModel, string RatedPower, string RatedVoltage, string RatedSpeed, string RatedCurrent, string RatedTorque, string PoleCount, string PeakCurrent, string TorqueCostant, string VoltageCostant, string Resistance, string Inductance)
        {
            this.MotorModel = MotorModel;
            this.RatedPower = RatedPower;
            this.RatedVoltage = RatedVoltage;
            this.RatedSpeed = RatedSpeed;
            this.RatedCurrent = RatedCurrent;
            this.RatedTorque = RatedTorque;
            this.PoleCount = PoleCount;
            this.PeakCurrent = PeakCurrent;
            this.TorqueCostant = TorqueCostant;
            this.VoltageCostant = VoltageCostant;
            this.Resistance = Resistance;
            this.Inductance = Inductance;
        }

        public override string ToString()
        {
            return $"Motor Model: {this.MotorModel}\n" +
                   $"Rated Power: {this.RatedPower}\n" +
                   $"Rated Voltage: {RatedVoltage}\n" +
                   $"Rated Speed: {RatedSpeed}\n" +
                   $"Rated Current: {RatedCurrent}\n" +
                   $"Rated Torque: {RatedTorque}\n" +
                   $"Pole Count: {PoleCount}\n" +
                   $"Peak Current: {PeakCurrent}\n" +
                   $"Torque Costant: {TorqueCostant}\n" +
                   $"Voltage Costant: {VoltageCostant}\n" +
                   $"Resistance: {Resistance}\n" +
                   $"Inductance: {Inductance}";
        }

        public string GetModel()
        {
            return this.MotorModel;
        }
    }
}
