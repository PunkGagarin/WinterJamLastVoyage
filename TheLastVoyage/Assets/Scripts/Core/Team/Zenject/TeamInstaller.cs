using UnityEngine;
using Zenject;

namespace Core.Team.Zenject {

    public class TeamInstaller : MonoInstaller {


        [SerializeField]
        private TeamView _teamView;

        [SerializeField]
        private TeamController _teamController;


        public override void InstallBindings() {
            Container.Bind<TeamView>()
                .FromInstance(_teamView)
                .AsSingle();

            Container.Bind<TeamController>()
                .FromInstance(_teamController)
                .AsSingle();
        }
    }

}