using Data;

namespace Game {

    public class PlayerHumanoid : Humanoid {

        public PlayerSettings Settings { get; private set; }

        public TrapBuilder TrapBuilder { get; private set; }

        public PlayerHumanoid(HumanoidController controller, PlayerHumanoidData humanoidData, PointOfView pointOfView) : base(controller, humanoidData, pointOfView) {
            Settings = humanoidData.PlayerSettings;
            TrapBuilder = new TrapBuilder(humanoidData.TrapSchemeDatas, pointOfView, Settings);
        }
    }
}

