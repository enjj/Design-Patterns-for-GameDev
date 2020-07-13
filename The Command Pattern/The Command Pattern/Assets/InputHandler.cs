using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour{

    [SerializeField]
    private GameObject _actor;
    private Animator _anim;
    private Command _keyQ, _keyW, _keyE , _upArrow;

    private List<Command> _oldCommands = new List<Command>();
    private Coroutine _replayCoroutine;
    private bool _shouldStartReplay;
    private bool _isReplaying;

    private void Start() {
        _keyQ = new PerformJump();
        _keyW = new PerformKick();
        _keyE = new PerformPunch();
        _upArrow = new MoveForward();

        _anim = _actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = _actor.transform;
    }

    private void Update() {
        if (!_isReplaying) {
            HandleInput();
        }

        StartReplay();
        
    }

    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            _keyQ.Execute(_anim);
            _oldCommands.Add(_keyQ);
        } else if (Input.GetKeyDown(KeyCode.W)) {
            _keyW.Execute(_anim);
            _oldCommands.Add(_keyW);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            _keyE.Execute(_anim);
            _oldCommands.Add(_keyE);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            _upArrow.Execute(_anim);
            _oldCommands.Add(_upArrow);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            _shouldStartReplay = true;
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            UndoLastCommand();
        }
    }

    private void StartReplay() {
        if (_shouldStartReplay && _oldCommands.Count > 0) {
            _shouldStartReplay = false;
            if (_replayCoroutine != null) {
                StopCoroutine(_replayCoroutine);
            }
            _replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    private IEnumerator ReplayCommands() {
        _isReplaying = true;
        for (int i = 0; i < _oldCommands.Count; i++) {
            _oldCommands[i].Execute(_anim);
            yield return new WaitForSeconds(1f);
        }
        _isReplaying = false;
    }

    private void UndoLastCommand() {
        Command c = _oldCommands[_oldCommands.Count - 1];
        c.Execute(_anim);
        _oldCommands.RemoveAt(_oldCommands.Count - 1);
    }

}

