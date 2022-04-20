using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class leaderboardInfo
{
    public string ID;
    public long Kill;
    public int rank;

    
    public leaderboardInfo(int _rank, string _ID, long _Kill)
    {
        ID = _ID;
        Kill = _Kill;
        rank = _rank;
    }
}
public class RankManager : MonoBehaviour
{
    string log;
    public TextMeshProUGUI killtext;
    public TextMeshProUGUI UserName;
    public TextMeshProUGUI UserRank;
    public List<leaderboardInfo> leadrKill;
    public GameObject RankPrefab;
    public Transform parent;
    public Sprite[] icons;
    public IScore[] MykillScore;
    public List<GameObject> rankob;

    IEnumerator startFunc()
    {
        int Ch = 0;
        yield return new WaitForSeconds(1);
        if (GameInfo.inst.PcTestMode)
        {
            yield break;
        }

            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_killcnt, GameInfo.inst.PlayerKill, success => Ch=1);
        UserName.text = GameInfo.inst.UserName;
        killtext.text = GameInfo.inst.PlayerKill.ToString();
        yield return new WaitUntil(() => Ch == 1);
        
        GPGSBinder.Inst.LoadAllLeaderboardArray(GPGSIds.leaderboard_killcnt, Score =>
        {
            MykillScore = Score;
            for (int i = 0; i < Score.Length; i++)
            {
                if (Score[i].userID.ToString() == GameInfo.inst.Id)
                {
                    UserRank.text = (i + 1).ToString();
                    long kill = Score[i].value;
                    if (GameInfo.inst.PlayerKill < kill)
                    {
                        GameInfo.inst.PlayerKill = (int)kill;
                        killtext.text = GameInfo.inst.PlayerKill.ToString();
                    }
                }
            }
        });


        GPGSBinder.Inst.LoadCustomLeaderboardArray(GPGSIds.leaderboard_killcnt, 8,
               GooglePlayGames.BasicApi.LeaderboardStart.TopScores, GooglePlayGames.BasicApi.LeaderboardTimeSpan.AllTime, (success, scoreData) =>
               {
                    //log = $"{success}\n";
                    if (success)
                   {


                       var scores = scoreData.Scores;


                       List<string> userIds = new List<string>();
                       List<string> username = new List<string>();
                        //foreach (IScore score in scores)
                        //{
                        //    

                        //}





                        for (int i = 0; i < scores.Length; i++)
                       {
                           userIds.Add(scores[i].userID);
                           GameObject rank = Instantiate(RankPrefab, parent);
                           rank.SetActive(true);
                           if (i == 0)
                           {
                               rank.transform.GetChild(0).GetComponent<Image>().sprite = icons[0];
                               rank.transform.GetChild(0).gameObject.SetActive(true);
                           }
                           else if (i == 1)
                           {
                               rank.transform.GetChild(0).GetComponent<Image>().sprite = icons[1];
                               rank.transform.GetChild(0).gameObject.SetActive(true);
                           }
                           else if (i == 2)
                           {
                               rank.transform.GetChild(0).GetComponent<Image>().sprite = icons[2];
                               rank.transform.GetChild(0).gameObject.SetActive(true);
                           }
                           else
                           {
                                //rank.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = scores[i].rank.ToString();
                                rank.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
                               rank.transform.GetChild(1).gameObject.SetActive(true);
                           }

                            //IUserProfile user = find


                            // string name = "";
                            //rank.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Test";
                            //rank.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = username[i];

                            rank.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = scores[i].value.ToString();
                            //Debug.Log(scores);
                            //Debug.Log(scores[i]);
                            //Debug.Log(scores[i].userID);
                            //Debug.Log(scores[i].rank);
                            //Debug.Log(scores[i].value);
                            //Debug.Log(scores[i].date);

                            rankob.Add(rank);


                       }

                       Social.LoadUsers(userIds.ToArray(), profile => {
                           for (int i = 0; i < profile.Length; i++)
                           {
                               username.Add(profile[i].userName);
                               rankob[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = username[i];
                                // Debug.Log(username[i]);
                            }
                       });
                   }
               });

    }
    private void Start()
    {
        // GameInfo.inst.PlayerKill = 100;




        //string g= PlayGamesPlatform.Instance.localUser.

        //UserRank.text = Social.LoadScores(GPGSIds.leaderboard_killcnt,success=> { };


        StartCoroutine(startFunc());

       


        






    }
    public void Show()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_killcnt);
    }
}
