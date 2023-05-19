using Data;

namespace UI {

    public class NoneSight : Sight {

        public override SightType SightType => SightType.None;

        public override void SetSpread(float spread) {
        }
    }
}

