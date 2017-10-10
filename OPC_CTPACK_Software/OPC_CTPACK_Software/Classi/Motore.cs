using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Motore
    {
        string Motor_Model;
        string Rated_Power;
        string Rated_Voltage;
        string Rated_Speed;
        string Rated_Current;
        string Rated_Torque;
        string Pole_Count;
        string Peak_Current;
        string Torque_Costant;
        string Voltage_Costant;
        string Resistance;
        string Inductance;

        public Motore(string Motor_Model, string Rated_Power, string Rated_Voltage, string Rated_Speed, string Rated_Current, string Rated_Torque, string Pole_Count, string Peak_Current, string Torque_Costant, string Voltage_Costant, string Resistance, string Inductance)
        {
            this.Motor_Model = Motor_Model;
            this.Rated_Power = Rated_Power;
            this.Rated_Voltage = Rated_Voltage;
            this.Rated_Speed = Rated_Speed;
            this.Rated_Current = Rated_Current;
            this.Rated_Torque = Rated_Torque;
            this.Pole_Count = Pole_Count;
            this.Peak_Current = Peak_Current;
            this.Torque_Costant = Torque_Costant;
            this.Voltage_Costant = Voltage_Costant;
            this.Resistance = Resistance;
            this.Inductance = Inductance;
        }

        public string GetModel()
        {
            return this.Motor_Model;
        }
    }
}
