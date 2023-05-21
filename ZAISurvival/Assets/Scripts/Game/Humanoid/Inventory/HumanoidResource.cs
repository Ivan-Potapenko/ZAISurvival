using Data;
using System.Threading;

namespace Game {

    public class HumanoidResource {

        public ResourceType Type { get; private set; }

        private ResourceData _resourceData;

        private int _count;

        public int Count {
            get { return _count; }
            private set {
                if (value > _resourceData.MaxCount) {
                    _count = _resourceData.MaxCount;
                }else if (value < 0) {
                    _count = 0;
                } else {
                    _count = value;
                }
            }
        }

        public HumanoidResource(ResourceData resourceData) {
            _resourceData = resourceData;
            Count = resourceData.StartCount;
            Type = resourceData.Type;
        }

        public ResourceUIData GetUIData() {
            var uiData = _resourceData.ResourceUIData;
            uiData.count = Count;
            return uiData;
        }

        public int GetFreeSpace() {
            return _resourceData.MaxCount - Count;
        }

        public void PutResource(int count) {
            Count += count;
        }

        public int PullResource(int count) {
            int result;
            if(Count <= count) {
                result = Count;
            }
            else {
                result = count;
            }
            Count -= count;
            return result;
        }
    }
}
