using Game;
using UnityEngine;

namespace UI {

    public enum ScreenType {
        Battle,
        BuildMenu,
    }

    public struct InterfaceScreenData {
        public PlayerHumanoid humanoid;
        public UIManager manager;
    }

    public abstract class InterfaceScreen : MonoBehaviour {

        protected InterfaceScreenData _interfaceScreenData;

        public virtual void Init(InterfaceScreenData interfaceScreenData) {
            _interfaceScreenData = interfaceScreenData;
        }

        public virtual void Show() {
            gameObject.SetActive(true);
        }

        public virtual void Hide() {
            gameObject.SetActive(false);
        }
    }
}
