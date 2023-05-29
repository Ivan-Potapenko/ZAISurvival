using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace UI {

    public class BuildMenuInterfaceScreen : InterfaceScreen {

        [SerializeField]
        private BuildMenu _buildMenu;

        public override void Init(InterfaceScreenData interfaceScreenData) {
            base.Init(interfaceScreenData);
            _buildMenu.Init(_interfaceScreenData.humanoid, interfaceScreenData.manager);
        }

    }
}
