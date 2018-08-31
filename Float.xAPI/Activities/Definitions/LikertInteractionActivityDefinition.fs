﻿// <copyright file="LikertInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Interop
open Float.xAPI.Languages

/// <summary>
/// An interaction which asks the learner to select from a discrete set of choices on a scale.
/// </summary>
type public ILikertInteractionActivityDefinition =
    /// <summary>
    /// A list of discrete choices on a scale.
    /// </summary>
    abstract member Responses: seq<IInteractionComponent>

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison>]
type public LikertInteractionActivityDefinition =
    struct
        /// <inheritdoc />
        val Name: ILanguageMap

        /// <inheritdoc />
        val Description: ILanguageMap

        /// <inheritdoc />
        val Type: Uri

        /// <inheritdoc />
        val MoreInfo: option<Uri>

        /// <inheritdoc />
        val Extensions: option<IExtensions>

        /// <summary>
        /// A single item id.
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <inheritdoc />
        val Responses: seq<IInteractionComponent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions."/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
        /// <param name="responses">A list of discrete choices on a scale.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctResponsesPattern, responses, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
            nullArg name "name"
            emptySeqArg name "name"
            nullArg description "description"
            emptySeqArg description "description"
            nullArg thetype "thetype"
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = correctResponsesPattern; Responses = responses; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "<%A: Name %A Description %A Type %A MoreInfo %A Extensions %A CorrectResponsesPattern %A Responses %A>" (this.GetType().Name) this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern this.Responses

        member this.InteractionType = Interaction.Likert

        interface ILikertInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
            member this.Responses = this.Responses
    end
