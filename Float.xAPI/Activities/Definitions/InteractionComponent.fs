﻿// <copyright file="InteractionComponent.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Languages
open Interop

/// <summary>
/// A choice within an interaction component.
/// </summary>
type public IInteractionComponent =
    /// <summary>
    /// Identifies the interaction component within the list.
    /// </summary>
    abstract member Id: string

    /// <summary>
    /// A description of the interaction component (for example, the text for a given choice in a multiple-choice interaction).
    /// </summary>
    abstract member Description: ILanguageMap option

[<CustomEquality;NoComparison;Struct>]
type public InteractionComponent =
    /// <inheritdoc />
    val Id: string

    /// <inheritdoc />
    val Description: ILanguageMap option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.Choice"/> struct.
    /// </summary>
    /// <param name="id">Identifies the interaction component within the list.</param>
    /// <param name="description">A description of the interaction component.</param>
    new (id, [<Optional;DefaultParameterValue(null)>] ?description) =
        invalidStringArg id "id"
        emptyOptionalSeqArg description "description"
        { Id = id; Description = description }
        
    /// <inheritdoc />
    override this.GetHashCode() = hash this.Id

    /// <inheritdoc />
    override this.ToString() = sprintf "<%A: Id %A Description %A>" (typeName this) this.Id this.Description

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? IInteractionComponent as interaction -> (this.Id, this.Description) = (interaction.Id, interaction.Description)
        | _ -> false

    interface IEquatable<IInteractionComponent> with
        member this.Equals other = this.Equals other

    interface IInteractionComponent with
        member this.Id = this.Id
        member this.Description = this.Description
