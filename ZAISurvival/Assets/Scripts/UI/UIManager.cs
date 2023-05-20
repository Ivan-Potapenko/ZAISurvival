using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public class UIManager : MonoBehaviour {

        [Serializable]
        private struct ScreenPrefab {
            public ScreenType ScreenType;
            public InterfaceScreen interfaceScreen;
        }

        [SerializeField]
        private ScreenPrefab[] _screenPrefabs;

        private Dictionary<ScreenType, InterfaceScreen> _screens = new Dictionary<ScreenType, InterfaceScreen>();

        private void Awake() {
            foreach(var screenPrefab in _screenPrefabs) {
                _screens.Add(screenPrefab.ScreenType, Instantiate(screenPrefab.interfaceScreen, gameObject.transform));
            }
            DeactivateScreens();
        }

        public void ActivateScreen(ScreenType screenType, InterfaceScreenData interfaceScreenData) {
            DeactivateScreens();
            _screens[screenType].Init(interfaceScreenData);
            _screens[screenType].Show();
        }

        private void DeactivateScreens() {
            foreach(var screen in _screens) {
                screen.Value.Hide();
            }
        }
    }
}

