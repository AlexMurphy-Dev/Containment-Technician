# Containment Technician

A small game-development project being built as the first run of an
AI-assisted game production and learning pipeline.

## Current Phase

Prototype V0.1

## Prototype Goal

Determine whether diagnosing and repairing increasingly ridiculous
technical problems is fun enough to support the game's core loop.

## Core Loop

Problem appears
→ Diagnose
→ Choose repair
→ System responds
→ Next problem

## Current Prototype

The first prototype contains a CoolingSystem that:

- owns its own status
- owns its current error reason
- can enter a faulted state
- accepts repair attempts
- remains faulted after an incorrect repair
- returns to working after the correct repair

## Current Learning Focus

- C# class responsibility
- object-owned state
- information hiding
- interaction between multiple objects
- game-state architecture

## Status

Early prototype. Not a finished game.