/*
 * Copyright : Bastien Hoffstetter 2015
 * This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace RussianVehiculeRoulette
{
    public class RussianVehiculeRoulette : Script
    {
        private bool _modActivated;
        //This is the probability that the vehicule explode when you press the key
        //In percent
        private readonly int _probaExplosion;
        public RussianVehiculeRoulette()
        {
            KeyUp += OnKeyUp;
            _modActivated = false;
            _probaExplosion = 100;
        }


        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0 && _modActivated)
            {
                //Verefy that the player is the driver
                Ped player = Game.Player.Character;
                Vehicle vehicle = player.CurrentVehicle;
                bool isDriver = vehicle.GetPedOnSeat(VehicleSeat.Driver) == player;

                //Generate a number between 1 and 100
                //If this number is below the choosen one the car explode, else nothing appens
                Random r = new Random();
                int nbGenerated = r.Next(0, 100);
                if (isDriver && nbGenerated <= _probaExplosion)
                {
                    UI.ShowSubtitle("Boom!");
                    Function.Call(Hash.EXPLODE_VEHICLE, vehicle, true, true);

                }

            }
            else if (e.KeyCode == Keys.X)
            {
                _modActivated = !_modActivated;
                UI.ShowSubtitle(_modActivated
                    ? "Mod Russian Vehicule Roulette is activated!"
                    : "Mod Russian Vehicule Roulette is desactivated!");
            }
        }
    }
}