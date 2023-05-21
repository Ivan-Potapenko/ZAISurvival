using Data;
using System.Collections.Generic;
using System.Linq;

namespace Game {

    public class HumanoidInventory {

        private Dictionary<ResourceType, HumanoidResource> _resources;

        public HumanoidInventory(List<ResourceData> resourceDatas) {
            _resources = new Dictionary<ResourceType, HumanoidResource>();
            foreach (var data in resourceDatas) {
                _resources.Add(data.Type, new HumanoidResource(data));
            }
        }

        public HumanoidResource Get(ResourceType type) {
            if (!_resources.ContainsKey(type)) {
                return null;
            }
            return _resources[type];
        }

        public ResourceUIData[] GetUIData() {
            var data = new List<ResourceUIData>();
            foreach (var resource in _resources) {
                data.Add(resource.Value.GetUIData());
            }
            return data.ToArray();
        }
    }
}

