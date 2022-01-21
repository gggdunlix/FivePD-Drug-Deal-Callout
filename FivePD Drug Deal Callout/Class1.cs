using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;

namespace DrugDeal
{
    [CalloutProperties("Drug Deal", "GGGDunlix", "0.0.1")]
    public class DrugDeal : Callout
    {
        Ped suspect, suspect2;
        Vehicle car;
        private Vector3[] coordinates = {
            new Vector3(627.0128f, 127.511f, 92.82616f),
            new Vector3(629.7624f, 144.2941f, 95.74957f),
            new Vector3(657.8113f, 254.5778f, 102.1793f),
            new Vector3(620.7443f, 622.7388f, 128.9111f),
            new Vector3(1115.356f, 248.5698f, 80.85571f),
            new Vector3(962.3829f, -99.33821f, 74.3532f),
            new Vector3(973.4736f, -138.676f, 74.25252f),
            new Vector3(964.8218f, -199.0847f, 73.20833f),
new Vector3(1023.341f, -235.1041f, 43.77357f),
new Vector3(1062.357f, -286.7002f, 50.80855f),
new Vector3(1101.627f, -225.8279f, 56.92353f),
new Vector3(550.8839f, -546.6978f, 24.74655f),
new Vector3(616.5104f, -375.873f, 24.79995f),
new Vector3(-2.013562f, -633.1041f, 35.7243f),
new Vector3(-17.93744f, -695.5576f, 32.09006f),
new Vector3(-141.6712f, -587.9175f, 32.1811f),
new Vector3(-331.9148f, -762.4495f, 33.72382f),
new Vector3(-304.094f, -765.5972f, 53.0016f),
new Vector3(-140.5025f, -1001.574f, 27.02804f),
new Vector3(-8.790848f, -1084.257f, 26.42785f),
new Vector3(11.65546f, -1069.671f, 37.90887f),
new Vector3(145.8953f, -1073.739f, 28.9399f),
new Vector3(152.4858f, -1054.721f, 28.97338f),
new Vector3(333.3826f, -1010.304f, 29.04843f),
new Vector3(285.1268f, -998.7891f, 28.98241f),
new Vector3(469.6723f, -859.2604f, 26.34447f),
new Vector3(472.6175f, -1096.728f, 28.95685f),
new Vector3(442.9755f, -1179.531f, 29.1089f),
new Vector3(414.0969f, -1221.426f, 32.38844f),
new Vector3(461.965f, -1230.498f, 29.76469f),
new Vector3(483.8307f, -1279.561f, 29.2981f),
new Vector3(465.0234f, -1314.427f, 28.99555f),
new Vector3(490.4728f, -1383.396f, 29.1034f),
new Vector3(485.888f, -1308.521f, 29.01287f),
new Vector3(507.7157f, -1498.078f, 29.04322f),
new Vector3(502.9705f, -1519.799f, 29.04183f),
new Vector3(484.6507f, -1525.311f, 29.0525f),
new Vector3(738.7255f, -1911.691f, 29.04861f),
new Vector3(733.6329f, -1978.615f, 29.0219f),
new Vector3(741.6309f, -1839.276f, 29.03538f),
new Vector3(667.1107f, -2166.334f, 4.327773f),
new Vector3(1042.478f, -3033.059f, 5.656638f),
new Vector3(1280.686f, -3329.344f, 5.658712f),
new Vector3(443.6342f, -3090.304f, 5.824807f),
new Vector3(238.3931f, -2997.769f, 5.502284f),
new Vector3(34.51588f, -2666.584f, 5.763305f),
new Vector3(-37.83871f, -2687.69f, 5.755503f),
new Vector3(-112.6446f, -2679.504f, 5.76118f),
new Vector3(-513.5895f, -2846.353f, 5.756155f),
new Vector3(-1032.857f, -2211.872f, 8.738094f),
new Vector3(-1077.64f, -1663.918f, 4.154183f),
new Vector3(-1105.479f, -1633.213f, 4.312765f),
new Vector3(-1101.697f, -1496.217f, 4.594522f),
new Vector3(-1208.447f, -1060.947f, 8.053208f),
new Vector3(-1267.028f, -821.7306f, 16.85461f),
new Vector3(-1346.726f, -751.4363f, 22.11236f),
new Vector3(-1675.163f, -1046.743f, 4.101147f),
new Vector3(-1596.593f, -1071.64f, 5.526896f),
new Vector3(-1200.782f, -720.0125f, 21.19158f),
new Vector3(-1216.218f, -669.8867f, 40.11036f),
new Vector3(-1180.411f, -696.5969f, 25.65731f),
new Vector3(-1102.795f, -455.4184f, 35.01229f),
new Vector3(-1349.966f, 135.2051f, 56.01595f),
new Vector3(-1212.075f, 351.8759f, 70.76755f),
new Vector3(-394.9829f, -80.91892f, 54.1766f),
new Vector3(-359.4865f, -52.28528f, 54.17588f),
new Vector3(-335.1878f, -56.74955f, 54.17652f),
new Vector3(-357.3878f, -95.73007f, 45.41257f),
new Vector3(-356.8644f, -113.0891f, 38.45201f),
new Vector3(-191.0455f, -158.6308f, 43.37634f),
new Vector3(-163.9527f, -42.43016f, 52.67062f),
new Vector3(50.09749f, -330.0273f, 43.75346f),
new Vector3(43.46384f, -387.5882f, 39.67729f),
new Vector3(866.0639f, -916.2826f, 25.77207f),
new Vector3(537.7644f, -1974.583f, 24.55501f),
        };

        public DrugDeal()
        {
            Vector3 location = coordinates.OrderBy(x => World.GetDistance(x, Game.PlayerPed.Position)).Skip(3).First();

            InitInfo(location);
            ShortName = "Drug Deal";
            CalloutDescription = "A drug deal is in progress. Get to the location and stop it. Respond in code 3..";
            ResponseCode = 3;
            StartDistance = 60f;
        }

        public async override Task OnAccept()
        {
            var cars = new[]
          {
               VehicleHash.Burrito,
               VehicleHash.Burrito2,
               VehicleHash.Burrito3,
               VehicleHash.Burrito4,
               VehicleHash.Burrito5,
               VehicleHash.GBurrito,
               VehicleHash.GBurrito2,
           };

            InitBlip();
            UpdateData();
            suspect = await SpawnPed(RandomUtils.GetRandomPed(), Location);
            suspect2 = await SpawnPed(RandomUtils.GetRandomPed(), Location);
            car = await SpawnVehicle(cars[RandomUtils.Random.Next(cars.Length)], World.GetNextPositionOnStreet(Location));
            car.Windows.RollDownAllWindows();
            CitizenFX.Core.Native.API.SetVehicleDoorOpen(CitizenFX.Core.Native.API., VehicleDoorIndex.BackLeftDoor, true, true);
            CitizenFX.Core.Native.API.SetVehicleDoorOpen(car, VehicleDoorIndex.BackRightDoor, true, true);
            suspect.AlwaysKeepTask = true;
            suspect.BlockPermanentEvents = true;
            suspect2.AlwaysKeepTask = true;
            suspect2.BlockPermanentEvents = true;
        }

        public override void OnStart(Ped player)
        {
            base.OnStart(player);
            suspect.Weapons.Give(WeaponHash.Bottle, 1, true, true);
            suspect2.Weapons.Give(WeaponHash.Bottle, 1, true, true);
            suspect.Task.FightAgainst(suspect2);
            suspect2.Task.FightAgainst(suspect);
            suspect.AttachBlip();
            suspect2.AttachBlip();
            suspect.Armor = 4000;
            suspect2.Armor = 4000;

        }
    }


}