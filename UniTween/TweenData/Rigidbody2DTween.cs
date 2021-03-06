﻿using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Tween Data/Rigidbody 2D")]
public class Rigidbody2DTween : TweenData {

    [Space(15)]
    public Rigidbody2DCommand command;

    [HideIf("HideVector2")]
    public Vector2 vector2;
    [HideIf("HideTo")]
    public float to;
    [HideIf("HideJumpVars")]
    public float jumpPower;
    [HideIf("HideJumpVars")]
    public int numJumps;
    [ShowIf("ShowSnapping")]
    public bool snapping = false;

    public override Tween GetTween(UniTween.UniTweenTarget uniTweenTarget)
    {
        Rigidbody2D rb = (Rigidbody2D)GetComponent(uniTweenTarget);

        switch (command)
        {
            case Rigidbody2DCommand.Move:
                return rb.DOMove(vector2, duration, snapping);
            case Rigidbody2DCommand.MoveX:
                return rb.DOMoveX(to, duration, snapping);
            case Rigidbody2DCommand.MoveY:
                return rb.DOMoveY(to, duration, snapping);
            case Rigidbody2DCommand.Jump:
                return rb.DOJump(vector2, jumpPower, numJumps, duration, snapping);
            case Rigidbody2DCommand.Rotate:
                return rb.DORotate(to, duration);
            default:
                return null;
        }
    }

    private bool HideVector2()
    {
        return command != Rigidbody2DCommand.Move && command != Rigidbody2DCommand.Jump;
    }

    private bool HideTo()
    {
        return command != Rigidbody2DCommand.MoveX && command != Rigidbody2DCommand.MoveY && command != Rigidbody2DCommand.Rotate;
    }

    private bool HideJumpVars()
    {
        return command != Rigidbody2DCommand.Jump;
    }

    private bool ShowSnapping()
    {
        return command.ToString().Contains("Move") || command == Rigidbody2DCommand.Jump;
    }

    public enum Rigidbody2DCommand
    {
        Move,
        MoveX,
        MoveY,
        Jump,
        Rotate
    }
}
