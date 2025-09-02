using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEngine.EventSystems.EventTrigger;

public class Character : Identity
{
    public int energy;
    public int attackPoint;
    protected bool isFreeze;

    public virtual void Move(Vector2 direction)
    {
        int toX = (int)(positionX + direction.x);
        int toY = (int)(positionY + direction.y);

        if (HasPlacement(toX, toY))
        {
            if (IsPotion(toX, toY))
            {
                positionX = toX;
                positionY = toY;
                transform.position = new Vector3(toX, toY, 0);
                mapGenerator.potions[toX, toY].Hit();
            }
            else if (IsDemonWalls(toX, toY))
            {
                positionX = toX;
                positionY = toY;
                transform.position = new Vector3(toX, toY, 0);
                mapGenerator.walls[toX, toY].Hit();
            }
        }
        else
        {
            positionX = toX;
            positionY = toY;
            transform.position = new Vector3(toX, toY, 0);
        }
    }

    public virtual void TakeDamage(int Damage)
    {
        energy -= Damage;
        CheckDead();
    }

    public virtual void TakeDamage(int Damage, bool freeze)
    {
        energy -= Damage;
        CheckDead();
    }

    public void Heal(int healPoint)
    {
        energy += healPoint;
    }

    protected virtual void CheckDead()
    {
        if (energy <= 0)
        {
            Destroy(gameObject);
        }
    }

    #region Map related methods ...

    /// <summary>
    /// HasPlacement method checks if the given position has any object or not.
    /// If there is an object or it is Walls (not walkable), it returns true, otherwise false.
    /// HasPlacement ใช้ในการตรวจสอบว่าตำแหน่งที่กำหนดมีวัตถุอะไรบ้าง ถ้ามีวัตถุหรือเป็นผนัง (ไม่สามารถเดินผ่านได้) จะคืนค่าเป็นจริง มิฉะนั้นเป็นเท็จ
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool HasPlacement(int x, int y)
    {
        string mapData = mapGenerator.GetMapData(x, y);
        return mapData != mapGenerator.empty;
    }

    public bool IsDemonWalls(int x, int y)
    {
        string mapData = mapGenerator.GetMapData(x, y);
        return mapData == mapGenerator.demonWall;
    }

    public bool IsPotion(int x, int y)
    {
        var mapData = mapGenerator.GetMapData(x, y);
        return mapData == mapGenerator.potion;
    }

    public bool IsExit(int x, int y)
    {
        var mapData = mapGenerator.GetMapData(x, y);
        return mapData == mapGenerator.exit;
    }

    #endregion
}