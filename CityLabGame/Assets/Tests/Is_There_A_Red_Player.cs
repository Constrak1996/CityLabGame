using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class Is_There_A_Red_Player
    {
        [UnityTest]
        public IEnumerator Is_There_A_Red_PlayerWithEnumeratorPasses()
        {
            var player = new GameObject();
            player.tag = "RedPlayer";
            player.name = "RedPlayer";

            Assert.IsTrue(player.tag == "RedPlayer");

            yield return new WaitForSeconds(5);
        }

        [UnityTest]
        public IEnumerator Is_There_A_Blue_PlayerWithEnumeratorPasses()
        {
            var player = new GameObject();
            player.tag = "BluePlayer";
            player.name = "BluePlayer";

            Assert.IsTrue(player.tag == "BluePlayer");

            yield return new WaitForSeconds(5);
        }
    }
}
